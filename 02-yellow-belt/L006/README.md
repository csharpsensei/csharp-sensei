# 006 — Choosing the Right Collection

🟨 **Yellow Belt** · Lists, Dictionaries and the cost of looking.

Video: _add the YouTube URL once V006 is published._

## Run it

```
dotnet run
```

## What this lesson covers

- Why an array's fixed size pushes bookkeeping into your code
- `List<T>`: `Add`, `Count`, the indexer, `Remove`, `Insert`, `RemoveAt`
- Why finding one item in a list is a **search**, and what that costs inside a loop
- `Dictionary<TKey, TValue>`: keys, values, hashing, and one-step lookup
- `TryGetValue` vs the indexer, `Add` vs `TryAdd`
- Five mistakes: the nested search, the missing key, the duplicate key,
  assuming insertion order, and mutating while iterating

## This week's drill

Open your own code. Find a `foreach` with an `if` inside it that is hunting for
one item by an identifier. Replace it with a dictionary built once outside the
loop.

## `snippets/`

One file per rendered still in the video, named with that still's ID
(`v006-08a3-1-foreach-count.cs` → `v006-08a3-1-foreach-count-still.png`).
They are read-along fragments, not compiled — `snippets/**` is excluded from
the build by the `.csproj`.

`.txt` snippets are console output or cost tables rather than C# source.

## Licence

MIT — see the repository root.
