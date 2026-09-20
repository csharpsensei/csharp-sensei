# L026, Prototype in C#: Clone It, and What Deep Copy Really Costs

🟩 Green Belt · combo G-P5 · design pattern P1.6 Prototype.
Video: C# Sensei. Code is MIT.

Run it:

```powershell
dotnet run
```

Four passes print, in the order the lesson argues them:

| Pass | What it shows |
|---|---|
| 1 | A shallow copy, four changes made to the copy, and two of them landing on the original as well |
| 2 | The same four changes through `DeepCopy`, and three reference identity checks |
| 3 | A `with` expression on a record, and the list both the copy and the original still share |
| 4 | Two types that both implement `ICloneable`, the same call on each, and two different answers |

No dates, no money and no culture sensitive formatting anywhere, so the output
is the same on any machine on any day.

## The layout

| Folder | What is in it |
|---|---|
| `Models/` | `Player` (immutable), `KitChoice` (mutable), `Formation` |
| `Sheets/` | `TeamSheet`, the prototype, with `ShallowCopy` and `DeepCopy` |
| `Modern/` | `SquadNote`, a record, for the `with` expression |
| `Legacy/` | `LegacySheet` and `LegacyRota`, both `ICloneable`, one shallow and one deep |
| `Serialising/` | `JsonCopier`, a deep copy by round trip, with its price named |
| `Reporting/` | Console formatting |
| `Seeding/` | The fixed squad |

## The code that is deliberately wrong, and where

`PRODUCTION-SYSTEM.md` §16.3: nothing on screen is a shape to copy unless it
says so. Two types here are deliberately wrong and both carry a doc comment
saying `DO NOT COPY THIS SHAPE`:

- **`Legacy/LegacySheet`** implements `ICloneable` with a shallow `Clone`.
- **`Legacy/LegacyRota`** implements `ICloneable` with a deep `Clone`.

Neither is wrong on its own. The point is that a caller holding an `ICloneable`
cannot tell the two apart, which is why the framework's own guidance is not to
implement it. Use a named method with a return type instead, as `TeamSheet`
does.

## One simplification, named rather than hidden

`Serialising/JsonCopier` deep copies by writing the object out and reading it
back. It is real and it works, and it is the wrong default: every type in the
graph has to be serialisable, anything the serialiser cannot see is silently
lost, and it is far slower than the copy `TeamSheet.DeepCopy` performs by hand.
It is in the tree because the lesson names both the trick and its price.

## This week's drill

Take one class in your own code that holds a `List<T>`, copy an instance of it
however you normally would, change the list on the copy, and then print the
original.
