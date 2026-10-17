# L041, Composite in C#: Treating a Tree Like a Single Item

🟩 Green Belt · combo G-P10 · design pattern P2.4 Composite.
Video: C# Sensei. Code is MIT.

Run it:

```powershell
dotnet run
```

| Pass | What it shows |
|---|---|
| 1 | A calculator that checks types one level deep, and gets a nested hamper wrong |
| 2 | One question, `Grams()`, asked of a whole box and of a single item |
| 3 | The whole tree walked, to any depth, without a single type check |
| 4 | A tin added three levels down: the composite is right, the calculator is not |

## The layout

| Folder | What is in it |
|---|---|
| `Packing/` | `IPackable`, `Item` (a leaf) and `Box` (the composite) |
| `Legacy/` | `ShippingCalculator`, the hook's bad smell. `DO NOT COPY THIS SHAPE` |
| `Seeding/` | `Hampers`, one fixed hamper |
| `Reporting/` | `Tree`, which walks any packable, and console helpers |

## Simplifications, named

- Weights are whole grams, so nothing depends on culture or rounding.
- `Box.Add` exists only on `Box`, not on `IPackable`. The video explains why.

## This week's drill

Find one place in your own code that asks an object what type it is before
deciding what to do, and see whether one method on a shared interface would let
you ask the same question of all of them.
