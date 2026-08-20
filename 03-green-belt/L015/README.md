# L015 , Interface Segregation Principle

Companion code for **V015 , Interface Segregation Principle in C#**.

```
dotnet run
```

Two passes, printed one after the other.

| Folder | What is in it |
|---|---|
| `Legacy/` | **DO NOT COPY.** One six member `IFileStore`, the store that can honour all of it, the store that can honour a third of it, the reader that depends on all of it anyway, and the six member test stub |
| `Storage/` | The three role interfaces and the two stores, after the split |
| `Thumbnails/` | The reader, now asking for `IReadFiles` only |
| `Publishing/` | The writer, asking for `IWriteFiles` only |
| `OverSplit/` | **DO NOT COPY.** One method per interface, and the four parameter constructor it produces |

`SetAccess` on both disk stores has an empty body with a comment saying why.
That is a demo simplification, named rather than hidden
(`PRODUCTION-SYSTEM.md` §16.3): the class genuinely can do it, which is the
only fact the lesson needs from it.

The one line that does not compile is commented out at the end of
`Program.cs`. Uncomment it to see the point of the whole lesson arrive from
the compiler rather than from a customer.
