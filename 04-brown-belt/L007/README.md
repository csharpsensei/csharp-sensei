# 007 — Async/Await From the Ground Up

🟫 **Brown Belt** · And why it isn't threading.

Video: _add the YouTube URL once V007 is published._

## Run it

```
dotnet run
```

No internet needed. `ReportApi` stands in for a remote service by awaiting a
timer rather than a network call — which is still genuine asynchronous waiting,
and holds no thread while it runs.

## What this lesson covers

- What `.Result` actually costs: a blocked thread, and thread pool starvation
  under load
- `async` and `await`: the method splits in two and returns to its caller
- Why async does not make one operation faster — it frees the thread
- **Async is not threading.** Waiting needs no thread; thinking does, and
  `Task.Run` is for the thinking
- `Task`, `Task<T>` and `void`: what an async method hands back, and why `void`
  is for event handlers only
- Five mistakes: `async void`, `.Result` / `.Wait`, `async` with no `await`
  (CS1998), not awaiting at all, and awaiting in a loop when the calls are
  independent

## This week's drill

Search your own code for `.Result` and `.Wait()`. For every one you find, work
out whether it can become an `await` — and if it cannot, work out what is
stopping it.

## `snippets/`

One file per rendered still in the video, named with that still's ID
(`v007-08a3-1-signature.cs` → `v007-08a3-1-signature-still.png`). They are
read-along fragments, not compiled — `snippets/**` is excluded from the build
by the `.csproj`.

`.txt` snippets are console output, cost tables or on-screen text rather than
C# source.

Four snippets are deliberately **not** reachable from `Program.cs`, because
running them would break the build or kill the process:

| Snippet | Why it is snippet-only |
|---|---|
| `v007-13c1-1-async-void.cs` | `async void` that throws — ends the process |
| `v007-17a1-1-mistake-async-void.cs` | the broken `async void` half of mistake 1 |
| `v007-17a3-1-mistake-no-await.cs` | warns CS1998 by design |
| `v007-17a4-1-mistake-not-awaiting.cs` | warns CS4014 by design |

`Program.cs` runs the fixed form of each and says so on the console.

## Licence

MIT — see the repository root.
