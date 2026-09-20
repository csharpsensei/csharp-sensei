# L025 — Naming, and the Comment You Shouldn't Need

⬜ White Belt. Combo CC-C1: CC1.1 Naming, CC1.2 Self-Documenting Code.

Run it:

```powershell
dotnet run --project code\L025\L025.csproj
```

`net10.0`, nullable enabled, no packages, no network, nothing to configure.

## What it prints

Four passes, in order, over the same six library loans and one fixed date of
20 March 2026. The dates are hard-coded so the output is the same on any
machine and on any day.

| Pass | What it does | What it proves |
|---|---|---|
| 1 | The overdue report twice: `Unclear/LendingDataManager.Process` and `Lending/LoanDesk.BuildOverdueReport` | Same three lines from both. Renaming changes nothing the machine sees |
| 2 | Deletes four comments (`Unclear/CommentedDesk` becomes `Lending/FeeTotals`) and extracts one method (`Unclear/InlineRules` becomes `Lending/OverdueRules`) | The totals match and the overdue test agrees on all six loans. Both moves are safe |
| 3 | `Misleading/StaleCommentDesk` and `Misleading/MemberLookup` | A comment that says three days over code that says seven, and a method called Get that writes. Neither is checked by anything |
| 4 | `Lending/LateFee.For` on a loan 77 days past due | The fee is capped. No method name can carry why the cap exists, so the comment above it is the only thing that does |

## The deliberately bad code, and why it is here

`PRODUCTION-SYSTEM.md` §16.3 says on-screen code either follows the practice we
would recommend, or it is labelled where it lives and in the README. Four types
are deliberately bad, every one of them carries a doc comment saying so, and
none of them is a pattern to copy:

| File | What is wrong with it on purpose |
|---|---|
| `Unclear/LendingDataManager.cs` | `Process`, `l`, `d`, `f`, `r`, `x`, `n`, `b`, `m`. Identical behaviour to `LoanDesk` |
| `Unclear/CommentedDesk.cs` | Four comments, each restating the line under it |
| `Unclear/InlineRules.cs` | The overdue test inline, with a comment where a method name belongs |
| `Unclear/BadNames.cs` | `loanList`, `ovrdCnt`, `strMemberName`, and a method called `Add` taking `l` and `f` |
| `Misleading/StaleCommentDesk.cs` | A comment that was true once and is now wrong |
| `Misleading/MemberLookup.cs` | `GetMemberRecord` writes to the record it returns |

## One simplification, named

`Lending/LendingPolicy.cs` is a static class of constants. That is the case the
singleton lesson explicitly left alone: no state, nothing to swap, nothing that
can be wrong. In a real desk these values would come from configuration, and
that would not change a single name in this lesson.

## Layout

One public type per file, folders by role (`PRODUCTION-SYSTEM.md` §16.2).
`Program.cs` is a composition root and holds the four passes and nothing else.

```
Lending/      the well named version, and the rules
Unclear/      names that say nothing
Misleading/   code that says something untrue
Reporting/    console formatting
Seeding/      the six loans
```
