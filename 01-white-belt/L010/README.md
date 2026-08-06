# L010 — Interfaces in C#

Code for **V010 — Interfaces in C#: Program Against the Shape, Not the Class**
(⬜ White Belt). MIT licensed, same as the rest of the repo.

```powershell
dotnet run
```

## What it shows

`Program.cs` is the **composition root** and the only file that names a concrete
destination. Everything else knows one thing: `IReportDestination`.

Run it and you get four passes over the same `ReportBuilder`:

1. a file destination
2. the console instead — one line changed, `ReportBuilder` untouched
3. several destinations at once, held in a `List<IReportDestination>`
4. a `RecordingDestination`, which is the test that was impossible when the
   builder created its own file writer

## Layout

| File | Why it exists |
|---|---|
| `Reporting/IReportDestination.cs` | the socket — members, no bodies, no data |
| `Reporting/INamed.cs` | a second contract, to show many interfaces on one class |
| `Reporting/FileDestination.cs` | implements both |
| `Reporting/ConsoleDestination.cs` | shares no code with the file one |
| `Reporting/NullDestination.cs` | sends nowhere, deliberately |
| `Reporting/RecordingDestination.cs` | the test double, four lines |
| `Reporting/ReportBuilder.cs` | the consumer — its field's **type** is the lesson |

One public type per file, folders by role (`PRODUCTION-SYSTEM.md` §16.2).

## Simplifications, named rather than hidden

- **`Build()` returns a fixed string.** A real report would come from somewhere;
  that is not what this lesson is about, and inventing a data source would put a
  second idea on screen.
- **No test framework.** Pass 4 prints PASS or FAIL rather than pulling in xUnit,
  because assertions are a 🟩 Green Belt subject and this is White Belt. The
  point being made is that the check is now *possible*, not how to write one.
- **`FileDestination` writes to `reports/`, relative to where you run it.** No
  configured path and no self-address — `PRODUCTION-SYSTEM.md` §16.6.

## The drill

Open your own code. Find one class that creates something inside itself with
`new`. Ask: would I ever want a different one of these, including a pretend one
in a test? If yes, pull out an interface and move the object into the
constructor. If the honest answer is no, leave it exactly as it is.
