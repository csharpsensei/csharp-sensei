# L021: Inside async/await in C#

Run it:

```
dotnet run --project L021.csproj
```

Three passes, all about one plain async method, `Compiled/AverageReading.cs`:

1. **What `await` really does.** The method is called, prints one line, and
   returns before it has an answer. The caller carries on. Later the rest of the
   method runs, and it is not on the thread it started on.
2. **The docket the compiler wrote.** `Inspect/DocketPrinter.cs` asks the
   runtime, through reflection, what the compiler generated for that method: the
   type's name, whether it is a struct, and every field it carries. No
   decompiler, no tooling. Three methods are inspected, so the contrast is
   visible: one that awaits twice, one marked `async` that awaits nothing, and
   one that is not `async` at all.
3. **The same method by hand.** `ByHand/ReadAverageMachine.cs` is
   `ReadAverageAsync` with the `async` keyword taken away and the machine
   written out in a file you can read. It logs its own state number on every
   `MoveNext`, and it returns the same answer as the compiler's version.

## Simplifications named rather than hidden

- **`Station.ReadAsync` awaits a timer, not a network.** The sample runs
  offline and still does real asynchronous waiting.
- **The readings are fixed, and both are exact in binary.** 11.25 and 13.75
  average to 12.5, which prints as `12.5` rather than as a tail of nines. Real
  sensor code would not be so obliging.
- **`Log.Where` prints "the main thread" or "a pool thread", never an id.**
  Thread ids change between runs, and the only fact this lesson needs is whether
  we are still on the thread the program started on.
- **The hand-written machine always parks.** The compiler checks
  `awaiter.IsCompleted` first and carries straight on when the answer is already
  there, which saves a hop. That check is left out of `ReadAverageMachine` on
  purpose: it doubles the size of every case and teaches nothing the rest of the
  file does not.
- **The hand-written machine is a `class`.** So is the compiler's, in a debug
  build. A release build generates a `struct`, and pass 2 prints which one you
  are looking at.
- **`ReadNothingAsync` is marked `async` and awaits nothing**, and the CS1998
  warning that would produce is suppressed on that method alone. The warning is
  the point, and pass 2 shows what it costs.
- **Field names like `<>1__state` are the compiler's choice, not the language's.**
  They are what Roslyn writes today. The state field, the builder and the
  hoisted locals have to exist; what they are called does not.
