# L035, Decorator in C#: Adding Behaviour Without Touching the Class

🟩 Green Belt · combo G-P7 · design pattern P2.5 Decorator.
Video: C# Sensei. Code is MIT.

Run it:

```powershell
dotnet run
```

| Pass | What it shows |
|---|---|
| 1 | Three lookups going straight to the courier: three calls |
| 2 | The same three through `CachingQuote`: one call |
| 3 | `LoggingQuote` and `CachingQuote` stacked in both orders: three log lines against one |
| 4 | `RetryingQuote` over a courier that fails once: two attempts, one answer |
| 5 | All three stacked over one courier |

## The layout

| Folder | What is in it |
|---|---|
| `Quotes/` | `IDeliveryQuote`, the real `CourierQuote`, a `FlakyCourierQuote`, and the transient exception |
| `Decorators/` | `CachingQuote`, `LoggingQuote`, `RetryingQuote`: one job each, same interface |
| `Legacy/` | `CourierQuoteWithEverything`, the hook's bad smell. `DO NOT COPY THIS SHAPE` |

## Simplifications, named

- **The courier is simulated.** It counts calls instead of making them, so the
  passes can prove how many reached it.
- **`CachingQuote` never expires anything.** A real cache needs an expiry and a
  size limit; this one exists to show the wrapping, not to be a cache.
- **`RetryingQuote` retries immediately.** A real retry waits, with backoff,
  and in .NET you would reach for a resilience library rather than write one.
- **The decorators are composed by hand** in `Program.cs`. A container does
  the same wiring; it does not change what a decorator is.

## This week's drill

Pick one class in your own code that does two jobs, where one of them is
logging, caching or retrying, and pull that job out into a wrapper that
implements the same interface.
