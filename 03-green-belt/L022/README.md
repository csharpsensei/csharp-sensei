# L022: Singleton in C#

Run it:

```
dotnet run --project L022.csproj
```

Three passes, all about one small billing job:

1. **The dependency you cannot see.** `Billing/InvoiceService.cs` has a
   constructor that takes nothing, so its signature says it depends on nothing.
   It calls `InvoiceNumbers.Instance` inside a method. The pass builds a
   brand new service object and shows that the numbering carries on from where
   the previous one left off, because the state is not on the service at all.
2. **Four threads reach for it at the same moment.** `Naive/RateTable.cs` uses
   the null check people usually write. Four real threads are held at a gate and
   released together, and the constructor runs four times. `Safe/RateTableOnce.cs`
   is the same class with a static field initialiser instead, and the constructor
   runs once.
3. **The same job, with the dependency declared.** `Injected/BillingService.cs`
   asks for an `IInvoiceNumbers` in its constructor. The pass shows two services
   sharing one source, two services with one source each, and a test handed a
   fake source. All three are impossible against the static version.

## Simplifications named rather than hidden

- **There is no container in this sample.** The lesson's answer is to register
  one instance with the application's container and inject it, and the code
  shows the shape that makes possible rather than adding a dependency on
  `Microsoft.Extensions.DependencyInjection` for one line. What the container
  does here is done by hand in `Program.cs`, which is what a composition root
  is.
- **`Thread.Sleep(60)` inside the naive property is there to make the race
  reliable.** Take it out and the same thing still happens, just not every run.
  A demonstration that only fails sometimes teaches nothing.
- **Four dedicated threads, not thread-pool work.** Pool work can be queued
  rather than started, and the point of the pass is that all four are genuinely
  inside the property at the same moment.
- **`RateTableOnce` carries an empty static constructor on purpose.** Without
  one the type is `beforefieldinit`, and the runtime may run the field
  initialiser earlier than the first access. That changes when the line is
  printed, never how many times.
- **The counters print `INV-1`, not a real invoice format.** Nothing in this
  lesson is about invoice numbering; it is about who owns the thing that
  generates them.
- **`Naive/InvoiceNumbers.cs` is written exactly as the pattern is usually
  taught.** It is not a straw man. The argument in this lesson is not that the
  code is badly written, it is that the decision it takes belongs somewhere
  else.
