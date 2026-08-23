# L016 — Dependency Inversion Principle

Code for the C# Sensei lesson *Dependency Inversion Principle in C#: Depend on
the Idea*. 🟩 Green Belt, the fifth and last of the five SOLID videos.

MIT licensed. Run it with:

```powershell
cd code\L016
dotnet run
```

## What is in here

| Folder | What it is |
|---|---|
| `Legacy/` | **Cycle a, the violation. Do not copy.** The review builds its own database in a field initialiser and reads `DateTime.Today` from the middle of the rule. |
| `Fines/` | **Cycle b, the high level rule**, and the two interfaces it owns: `IListLoans` and `IClock`. They live here, next to the code that needs them, because that is the principle. |
| `Library/` | **Cycle b, the low level detail.** `LoanDatabase` and `SystemClock`. Both have a `using` pointing at `Fines`. Nothing in `Fines` points back. |
| `Doubles/` | `FixedClock`, four lines, no mocking library. The seam the old version did not have. |
| `OverSplit/` | **Cycle c, the boundary. Do not copy.** An interface for everything, one implementation each, and a six parameter constructor nobody can read. |
| `snippets/` | One file per rendered still in the video, sharing that still's id. Excluded from the build. |

## The rule this code applies

High level modules should not depend on low level modules. Both should depend
on abstractions. The abstraction belongs to the high level side, named in that
side's own words.

## Simplifications, named rather than hidden

`PRODUCTION-SYSTEM.md` §16.3: on screen code follows the practice we would
recommend, or it says where it does not.

1. **`LegacyLoanDatabase` and `LoanDatabase` return a list.** A real loan
   database opens a connection and runs a query. Neither one does, because the
   lesson is about which way a dependency points and not about SQL. The shape
   of the dependency is identical either way.
2. **`OverSplit/OverSplitStorage.cs` declares five interfaces in one file.**
   That is legal C# and it is done so all five fit on one still. A real
   codebase built that way would carry five more files, which is part of what
   the cycle c section is arguing.
3. **`Program.cs` hands the review a `FixedClock`** for two of its three runs.
   In production you hand it `SystemClock`. The fixed one is there so the
   output on screen reads the same every time you run this.

## Money

Fines are whole pence, printed as integers (`190p`). No decimal formatting and
no currency symbol, so the output is identical on every console and in every
culture.

## This week's drill

Open one class in your own code that holds a real business rule. Find every
line in it that reaches outside the class: a `new`, a static call, a date, a
file, a connection. Write that list down. For each one, answer one question:
what would the second implementation be? Invert the ones you can answer, and
leave the rest alone.
