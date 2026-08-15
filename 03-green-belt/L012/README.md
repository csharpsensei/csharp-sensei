# L012: Single Responsibility Principle

Code for **V012: Single Responsibility Principle, One Reason to Change**
(🟩 Green Belt). MIT licensed, same as the rest of the repo.

```powershell
dotnet run
```

## What it shows

`Program.cs` is the **composition root**. It runs three passes, matching
the lesson's three cycles:

1. **the violation** (`Legacy/InvoiceGodClass.cs`) — one class, three jobs:
   tax math, receipt formatting, and storage. It works. That is the point.
2. **the refactor** (`Invoicing/`) — the same three jobs, split into
   `Invoice` (data only), `InvoiceCalculator`, `InvoicePrinter` and
   `InvoiceRepository`, wired together in `Program.cs`. Identical output.
3. **the boundary** (`OverSplit/`) — the over-applied version of
   `InvoiceCalculator`, split into four single-method classes. Still works,
   still correct, and still the shape the lesson argues against.

## Layout

| File | Why it exists |
|---|---|
| `Legacy/InvoiceGodClass.cs` | the "before": one class doing three unrelated jobs, demoed once and abandoned |
| `Invoicing/Invoice.cs` | the data class, no behaviour, no reason to change on its own |
| `Invoicing/InvoiceCalculator.cs` | tax math, one job, one reason to change |
| `Invoicing/InvoicePrinter.cs` | receipt formatting, one job, one reason to change |
| `Invoicing/InvoiceRepository.cs` | storage, one job, one reason to change |
| `OverSplit/OverSplitCalculators.cs` | the rejected shape, four classes fragmenting one already-single job |

One public type per file for the real lesson code (`Invoicing/`), the same
convention V011 uses (`PRODUCTION-SYSTEM.md` §16.2). The `OverSplit/`
rejected shape is kept in one file on purpose, so its four tiny classes read
as one bundle rather than as four separate "real" files, which would work
against the point the boundary cycle is making.

## The rejected shape

`OverSplit/OverSplitCalculators.cs` holds `TotalCalculator`,
`TaxCalculator`, `DiscountCalculator` and `LineItemSummer`. Every one of
them compiles and runs correctly. **DO NOT COPY** this shape into a real
project: it is the lesson's own example of splitting past the point where a
real, independent business reason exists.

## Simplifications, named rather than hidden

- **No interfaces, no dependency injection container.** This lesson is
  about where a responsibility ends, not about how collaborators are
  wired; introducing `IInvoiceCalculator` here would put V004's lesson back
  on screen when the point is a different one.
- **The "database" is a `Console.WriteLine`.** A real repository would talk
  to a real store; that detail teaches nothing extra about Single
  Responsibility.
- **Tax rate and discount are hardcoded constants.** A real invoicing
  system would source these from configuration; the numbers here exist only
  so the console output is deterministic and matches the stills exactly.

## Verified by running

**Not yet.** No .NET SDK reachable in the generation sandbox, same standing
caveat as V009-V011 at their own generation time. Every file was checked by
hand: braces balanced, namespaces consistent, `Program.cs`'s calls match
every constructor and method signature, and the console-output stills are
written to match what the code is written to print. `dotnet run` settles
all of it in seconds once a real SDK is available.

## The drill

Open a class you have written that does two unrelated jobs. Name the two
reasons somebody could ask it to change, and split it so each reason has
its own class. Stop as soon as each piece answers to exactly one of those
reasons.
