# L036, Async Deadlock in C#: .Result, ConfigureAwait and the Fix

🟫 Brown Belt · combo BR-C3 · A2.8 The .Result Pitfall and A1.6
ConfigureAwait(false). A1.7 Best Practices is not in this lesson.
Video: C# Sensei. Code is MIT.

Run it:

```powershell
dotnet run
```

Pass 1 takes about two seconds on purpose: that is the timeout reporting the
deadlock rather than hanging.

| Pass | What it shows |
|---|---|
| 1 | `.Result` on a one-thread context: deadlocked, reported after two seconds |
| 2 | The same `.Result` on a plain console thread: it works, which is why the bug hides |
| 3 | `await` all the way: it finishes, and resumes on the context thread |
| 4 | `.Result` over a library that uses `ConfigureAwait(false)`: no deadlock, still blocking |
| 5 | `ConfigureAwait(false)` in the handler itself: it resumes off the context thread |

## Simplifications, named

- **`Threading/SingleThreadContext`** is written for the lesson. A console app
  has no `SynchronizationContext`, so the deadlock cannot happen there; this
  class behaves like a desktop UI thread so it can be shown. In a real app the
  framework supplies the context.
- **Every wait has a timeout** so a deadlock prints a line instead of hanging.
  The deadlocked thread is a background thread and goes when the program ends.
- **`Legacy/BlockingCaller`** blocks on async code with `.Result`. That is the
  mistake the lesson is about. Do not copy it.

## This week's drill

Search your code for `.Result`, `.Wait()` and `GetAwaiter().GetResult()`, and
for each one, work out which thread it runs on and whether that thread has a
context.
