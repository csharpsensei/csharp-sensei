# L034, Generics in C#: Type Safety, List of T and where T

🟨 Yellow Belt · combo Y-C2 · F3.3 Generics 101 and F3.4 Type Constraints,
with F3.2 List of T against ArrayList as the opening bad smell.
Video: C# Sensei. Code is MIT.

Run it:

```powershell
dotnet run
```

| Pass | What it shows |
|---|---|
| 1 | An `ArrayList` accepts a string among the weights, and the sum throws at runtime |
| 2 | The same weights as `List<int>`, where the string could never have been added |
| 3 | `RecentItems<T>`, one class written once, used with `int` and with `string` |
| 4 | `Ranking.Largest<T>` with `where T : IComparable<T>`, used with three types |

## Simplifications, named

- **`Legacy/UntypedHarvestLog`** catches `InvalidCastException` by name and
  reports which item failed, so the pass can print it. That is the bad smell,
  not a pattern to copy. Do not copy it.
- **`Legacy/UnconstrainedRanking`** branches on `typeof(T)`. Mistake two. No
  pass runs it. Do not copy it.
- The line that does not compile, `weights.Add("12")` on a `List<int>`, is not
  in the source tree, because a project that does not build cannot be run. The
  video shows it on a card with the compiler's message.

## This week's drill

Find one method in your own code that takes or returns `object` and casts it
back, and rewrite it with a type parameter so the cast disappears.
