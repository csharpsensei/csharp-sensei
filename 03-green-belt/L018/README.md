# L018: The Factory Pattern in C#: Move the new Out of the Caller

🟩 Green Belt · combo G-P1 · the first pattern of the design patterns run.

One console app, one domain, one pattern taken from its lightest form to the
Gang of Four one. A warehouse stocktake is exported, and the only question in
the whole lesson is who decides which exporter gets built.

```
dotnet run
```

## What it prints

Three passes over the same three counted stock lines.

- **Pass 1** is `Legacy/`: the format chosen at the call site with a chain of
  conditionals, in two separate files. It works, and the second file is the
  problem. The program proves the duplication rather than asserting it.
- **Pass 2** is a Simple Factory. **The file name and the four rows under it are
  identical to pass 1**, on purpose. A pattern is not a feature.
- **Pass 3** is Factory Method: two jobs that share every step of an export and
  disagree about one thing, so that one thing is the only thing they override.

## The two shapes, and the line between them

| Folder | Shape | Who decides | When you want it |
|---|---|---|---|
| `Exporting/ExporterFactory.cs` | Simple Factory | One `switch`, in one place, keyed on data | The choice comes from a value at runtime, and one list of options is enough |
| `Jobs/ExportJob.cs` | Factory Method | A subclass, by overriding one method | The steps around the choice are shared, and the choice belongs to the caller's own type |

**Simple Factory is not one of the Gang of Four twenty three.** It is the
lightest thing in the creational family, it is where most code correctly stops,
and calling it "the Factory pattern" in a code review is how two people end up
meaning different things by one word.

## Simplifications, named rather than hidden

`PRODUCTION-SYSTEM.md` §16.3: on-screen code models the practice we would
recommend, or it says where it does not.

1. **`JsonExporter` writes its JSON by hand.** A real one uses
   `System.Text.Json`. This one spells the string out so every character on
   screen is one you can read, and so the output is fixed rather than dependent
   on a serialiser's defaults.
2. **Nothing is written to disk.** Every exporter returns lines and the program
   prints them, so it runs anywhere with no permissions and no cleanup.
3. **`ExporterFactory` is a static class.** That is the honest shape for a
   simple factory. An injectable factory is the shape you want the moment the
   factory itself needs a dependency, and that is named in the lesson rather
   than demonstrated here.
4. **`Legacy/NightlyBackup.cs` is deliberately a copy.** It exists to be the
   second place the same decision was written. Do not tidy it; it is the
   exhibit.
5. **Three stock lines is a small sample**, which is fine because nothing here
   aggregates or measures. §16.5 applies to lessons whose payoff is a statistic;
   this one's payoff is a shape.

## This week's drill

Search your own codebase for one interface name and count how many files say
`new` followed by one of its implementations. If the answer is one, you already
have a factory and it does not need a name. If the answer is four, you have
found the decision that got written down four times, and you now know what to
call the fix.
