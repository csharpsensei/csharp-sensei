# 008 — Wide Events in C#

⬛ **Black Belt** · Video: *Wide Events in C#: Why Your Logs Can't Answer Questions*

One wide event per request, per service — instead of seventeen log lines that
individually say nothing. Then the part that matters: querying them.

## Layout

```
Events/     WideEvent, its accessor, and the middleware that emits it
Models/     CheckoutRequest
Payments/   IPaymentGateway + a simulated one with deliberate latency
Seeding/    TrafficSeeder — generates enough volume for a percentile to mean something
```

`WideEventExtensions` sits in `Events/` rather than a general `Extensions/`
folder: it exists only to serve `WideEvent`, so it is grouped by what it is
cohesive with rather than by what kind of thing it is.

## 1. Run it locally — no Azure needed

```bash
dotnet run
```

### Which port?

**Read it off the console.** Kestrel prints `Now listening on: http://...` at
startup, and that is the only address this project treats as true.

The port is declared in exactly one place — `applicationUrl` in
`Properties/launchSettings.json`. Nothing in the source, the `README` or the
app's own behaviour depends on that value, so if your console prints something
else (running the built DLL, a container, `--no-launch-profile`, or an
`ASPNETCORE_URLS` you have set), just use what it printed.

Set `@host` at the top of `L008.http` to whatever the console said, then click
**Send Request** on any block. Works in Visual Studio 2022, Rider and the VS
Code REST Client.

With no connection string set, telemetry stays local and every wide event is
written to the console. That is enough to see the pattern.

<details>
<summary>Prefer the command line?</summary>

Set `$base` once, from the console line, and every example below follows it.

**PowerShell** — note `curl` is an alias for `Invoke-WebRequest`, which does
not understand `-X`/`-H`/`-d`:

```powershell
$base = "<the address the console printed>"
$body = @{ userId = "u_88214"; tier = "enterprise"; total = 1299.99; items = 7 } | ConvertTo-Json
Invoke-RestMethod -Uri "$base/checkout" -Method Post -ContentType "application/json" -Body $body
```

**bash**:

```bash
base="<the address the console printed>"
curl -X POST "$base/checkout" \
     -H "Content-Type: application/json" \
     -d '{"userId":"u_88214","tier":"enterprise","total":1299.99,"items":7}'
```

</details>

## 2. Send it to Application Insights

```bash
dotnet add package Azure.Monitor.OpenTelemetry.AspNetCore
```

The connection string is **never** written into `appsettings.json` and never
committed. Two supported ways to supply it:

**User secrets — recommended for local work.** Stored in your user profile,
outside the project directory, so it cannot be committed even by accident:

```bash
dotnet user-secrets set "APPLICATIONINSIGHTS_CONNECTION_STRING" "<your connection string>"
```

**Environment variable — what you would use anywhere else:**

```bash
export APPLICATIONINSIGHTS_CONNECTION_STRING="<your connection string>"   # bash
```
```powershell
$env:APPLICATIONINSIGHTS_CONNECTION_STRING = "<your connection string>"   # PowerShell
```

Microsoft recommends setting the connection string in code only in local
development and test. This project does not set it in code at all — Azure
Monitor reads it from configuration itself.

On startup the app logs which mode it is in, so you are never guessing whether
telemetry is actually leaving the machine.

### Sampling is on by default, and it will lie to you

Since **Distro 1.5.0** the default sampler is *rate limited* — **5 traces per
second**, not a percentage. Seed 400 checkouts in 17 seconds and roughly 85
reach the portal. Every percentile below would be computed from a fifth of the
data, and nothing would look broken.

The obvious fix does not work on its own: `TracesPerSecond` **takes precedence
over** `SamplingRatio`, so setting the ratio to 1.0 changes nothing until the
rate limit is switched off. `Program.cs` does both:

```csharp
o.TracesPerSecond = null;
o.SamplingRatio = 1.0F;
```

Keep everything while you are learning. Turn sampling back on when volume, not
understanding, is the constraint.

## 3. Generate enough data to query

A percentile over nine requests is not a percentile. Seed first:

```
POST {{host}}/seed?count=400&concurrency=16
```

There is a block for this in the `.http` file — use that. It takes 20–30
seconds; the simulated gateway has deliberate latency, which is the whole point.

`/seed` sends its traffic to whatever address you called it on, so it cannot
disagree with the port the app is actually listening on. If you see a wall of
`connection refused` warnings, the address you called is not the app.

**Then wait 2–5 minutes for ingestion** before running any KQL. An empty result
straight after seeding is normal, not a broken pipeline.

## 4. Ask it questions

Every field you `Set` becomes a tag on the request's `Activity`, and **every
Activity tag is exported as a custom dimension** — arriving in
`customDimensions` on the `requests` table.

```kusto
requests
| where name == "POST /checkout"
| extend tier = tostring(customDimensions["user.tier"])
| summarize p95 = percentile(duration, 95), count() by tier
| order by p95 desc
```

More queries in the video and in the lesson's shot list.

## What the simulated gateway does, and why

`SimulatedPaymentGateway` deliberately makes enterprise customers with large
carts slower and more likely to decline. That is a simulation, not a claim
about any real payment provider — but it means the numbers your queries return
are honestly derived from what the code actually did, rather than invented for
a slide.

## The drill

Take one endpoint in your own codebase and give it a wide event with at least
eight dimensions. Then go and ask it a question you have never been able to
ask.

## Credit

The framing — that your logs are lying to you, and that the fix is one wide
event per request — comes from Boris Tane's *Logging Sucks*
(<https://loggingsucks.com/>). The ideas are his; this C# is ours.

MIT licensed, like the rest of the repo.
