# L042, WhenAll, WhenAny and Cancellation in C# Async

🟫 Brown Belt · combo BR-C4 · A2.1 WhenAll/WhenAny and A2.3 CancellationToken.
A2.2 Task.Run vs ConfigureAwait is not in this lesson.
Video: C# Sensei. Code is MIT.

Run it:

```powershell
dotnet run
```

| Pass | What it shows |
|---|---|
| 1 | Three quotes awaited one after another: about the sum of the waits |
| 2 | The same three started together with `Task.WhenAll`: about the longest wait |
| 3 | `Task.WhenAny` books the first answer, then the others are cancelled |
| 4 | `WhenAll` with a 150 ms deadline: one answers, the deadline cancels the rest |
| 5 | Two failures under `WhenAll`: `await` rethrows one, the task holds both |

Times are rounded **down** to the nearest 100 ms, because a delay can take
longer than asked but never shorter.

## Simplifications, named

- **`TaxiFirm` waits on `Task.Delay`** instead of calling a real service. The
  token is passed to the delay, which is exactly what a real call should do
  with it.
- The firm names are made up.

## This week's drill

Find one method in your own code that takes a `CancellationToken`, and check
that every async call inside it is given that token.
