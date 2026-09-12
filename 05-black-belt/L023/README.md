# L023: Tail sampling, and what OpenTelemetry will not do for you

Run it:

```
dotnet run --project L023.csproj
```

No packages, no collector, no web server. Everything here is in the base class
library: `System.Diagnostics.ActivitySource`, `ActivityListener` and
`Activity`, which are the same types the OpenTelemetry .NET SDK listens to.

Three passes over the same two thousand checkouts:

1. **Head sampling, decided before the request runs.** `Sampling/HeadSampler.cs`
   installs an `ActivityListener` whose `Sample` callback keeps one in twenty.
   .NET calls that callback *before* the `Activity` object is created, so a
   checkout that is not sampled never becomes a trace at all. The pass prints
   how many of the failures survived, and the answer is four out of a hundred
   and ten.
2. **Tail sampling, decided once the trace has ended.**
   `Sampling/TraceBuffer.cs` records every activity and holds it;
   `Sampling/TailPolicy.cs` then judges each finished trace against four rules
   in order: it failed, it was slow, the customer is a vip, otherwise a one in
   twenty baseline. Every failure is kept, and the total kept is a fraction of
   the traffic rather than all of it.
3. **The same policy with only the framework's own attributes.** The vip rule
   is given nothing to match on, because `http.route`, the status code and the
   duration are all a framework can give you. The rule matches nothing and
   eighty one vip checkouts disappear.

## Simplifications named rather than hidden

- **There is no collector here.** `TailPolicy` is a hand written version of
  what the OpenTelemetry collector's tail sampling processor does from a list
  of policies in YAML, and the buffer is in this process rather than in a
  separate one. That difference is the second half of the lesson, so it is
  said out loud rather than glossed: in production the buffer and the policy
  are somewhere else, and they are stateful, and that is what they cost.
- **`Sampling/Deterministic.cs` stands in for hashing the trace id.** A real
  head sampler hashes the trace id so the decision is consistent across every
  service in one trace. That is random per run, which is right in production
  and useless on screen, so this sample uses a seeded generator and prints the
  same numbers every time.
- **Durations are real, and no duration is ever printed.** A slow checkout
  sleeps for twenty five milliseconds and the policy's threshold is ten, so
  the counts are the same on any machine, but a measured time is not
  reproducible and the sample never puts one on screen.
- **One span per checkout, not a distributed trace.** A real tail sampler
  waits for every span in a trace to arrive from every service, and deciding
  that it has probably seen them all is the hard operational part. One span
  per trace removes that so the policy is the thing you are looking at.
- **`cart.value` is `order.Id % 400`.** It exists to show a business attribute
  on the span, and nothing in the sample reads it.

## Where the numbers come from

`Checkout/Workload.cs` builds the same two thousand orders every run: four per
cent vip, six per cent failing, five per cent slow. Every count printed is
counted from that list or from the activities the listeners actually received.
Nothing is asserted.
