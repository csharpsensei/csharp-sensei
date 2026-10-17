# L040, IEnumerable and yield in C#: How foreach Really Works

🟨 Yellow Belt · combo Y-C3 · F3.7 IEnumerable vs IEnumerator and F3.8 yield,
with F3.9 (LINQ is built on this) as one block that points at V019.
Video: C# Sensei. Code is MIT.

Run it:

```powershell
dotnet run
```

| Pass | What it shows |
|---|---|
| 1 | `foreach` over a hand-written `IEnumerable<string>`, and the same walk written by hand |
| 2 | Two enumerators over one list, each with its own place |
| 3 | A `yield` method: nothing runs when it is called; each item is made as it is asked for |
| 4 | An endless `yield` sequence, and `Take(3)` asking for only three |

## The layout

| Folder | What is in it |
|---|---|
| `Reading/` | `ReadingList`, an `IEnumerable<string>` written by hand, and `Bookmark`, its `IEnumerator<string>` |
| `Sequences/` | Two `yield` methods: `Pages.Written` and `Counting.From` |

## Simplifications, named

- **`ReadingList` and `Bookmark` are written by hand to show the two halves.**
  In real code a `yield` method, or a collection that already implements
  `IEnumerable<T>`, does this for you.
- **`Pages.Written` records into a list** so the order of events can be
  printed afterwards. It is the order that matters, not the list.

## This week's drill

Take one method in your own code that builds a whole list and returns it, and
ask whether every caller needs every item. If not, try it as a `yield` method.
