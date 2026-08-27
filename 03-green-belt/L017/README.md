# L017 — Design Patterns in C#: What They Are and Why They Exist

🟩 Green Belt · combo G-C0 · the design patterns opener.

One console app, one domain, three light-touch examples: one from each of the
three pattern families. It is deliberately not a deep dive into any of them.

```
dotnet run
```

## What it prints

Three passes over the same three departures.

- **Pass 1** is `Legacy/HandBuiltBoard.cs`: one method that decides what to
  build, reads the feed's packed format, and picks the wording. It works.
- **Pass 2** is the same behaviour with the three named solutions in place. The
  output is identical, on purpose. A pattern is not a feature.
- **Pass 3** is the same board with one constructor argument different.

## The three families, one file each

| Folder | Family | The named solution | What it varies |
|---|---|---|---|
| `Creating/` | Creational | Simple Factory (`ServiceFactory`) | How the object comes into existence, and who decides which one |
| `Wrapping/` | Structural | Adapter (`RegionalTimetableAdapter`) | How parts are put together so the assembly does what no part did alone |
| `Choosing/` | Behavioural | Strategy (`IDelayPolicy`) | How the parts behave and hand work to each other as conditions change |

The folder names are the plain English versions. The pattern names are the
shorthand for exactly the same thing, and the shorthand is most of the value.

## Simplifications, named rather than hidden

`PRODUCTION-SYSTEM.md` §16.3: on-screen code models the practice we would
recommend, or it says where it does not.

1. **`RegionalTimetable` is a stand-in for a third party feed.** It returns
   hard-coded rows so the program runs anywhere with no network and no
   database. Treat it as a file you are not allowed to edit, because that is
   the situation the adapter exists for.
2. **`ServiceFactory` is a static class.** A simple factory is the lightest
   member of the creational family and a static method is the honest shape for
   it. The factory patterns that take an instance, and the reasons to prefer
   them, are a lesson of their own.
3. **The composition root is `Program.Main`.** There is no dependency injection
   container anywhere in this project, and none is needed to show any of this.
4. **Three departures is a small sample**, which is fine here because nothing in
   this lesson aggregates or measures. §16.5 applies to lessons whose payoff is
   a statistic; this one's payoff is a shape.

## This week's drill

Open a file in your own code that you have edited three times for three
unrelated reasons. For each edit, write down in one plain sentence what varied:
what got built, how two things were joined, or which rule ran. Then look up
whether that variation has a name. You are not refactoring anything. You are
finding out how much of what you have already solved was already solved.
