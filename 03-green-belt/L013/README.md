# L013 — Open/Closed Principle: Extend Without Editing

🟩 Green Belt · SOLID, second letter · C# Sensei

Run it:

```powershell
dotnet run
```

Four passes print to the console. The prices are identical in every pass that
prices the same carrier, which is the point: nothing about *what* the program
does changes across the refactor. Only *where the next change lands* changes.

## What is in here

| Folder | What it is |
|---|---|
| `Legacy/` | **The violation. DO NOT COPY.** One method, one switch, every carrier's pricing rule inside it. Kept runnable so the lesson can show it working before replacing it. |
| `Shipping/` | The refactor. `IShippingRate` is the seam, one class per carrier behind it, and `ShippingCalculator` names no carrier at all. |
| `OverAbstracted/` | **The boundary. DO NOT COPY.** The same feature with a seam at every joint: a factory, an interface for the factory, and a provider that looks carriers up by name. Every seam is open for extension and the result is worse than both versions above. |
| `snippets/` | One read-along file per rendered still, sharing that still's ID. Excluded from the build. |

## The drill

Find a `switch` or an `if` chain in your own code that has grown a case more
than once. Write down what varies across the cases, define an interface for
that one thing, and move a single case into a class behind it. One case, not
all of them. Then see whether the next case is easier than the last.

## Two things stated rather than hidden

1. **The culture is pinned in `Program.cs`.** The lesson prints money, and
   `:C` formatting follows the machine's regional settings, so without
   `CultureInfo.DefaultThreadCurrentCulture` the same code prints different
   symbols on different computers. Pinning it is what makes the console output
   in the video reproducible on your machine.
2. **`OverAbstracted/` groups several types into one file**, which
   `PRODUCTION-SYSTEM.md` §16.2 says not to do. That is deliberate and it is
   the only deviation in this project: the whole point of that example is how
   much reading one small feature costs, and spreading it across four files
   would make the example harder to see rather than easier. It is labelled
   DO NOT COPY at the top of the file for the same reason.

Code is MIT licensed: https://github.com/csharpsensei/csharp-sensei
