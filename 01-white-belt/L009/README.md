# L009 — How Inheritance Really Works

⬜ White Belt · C# Sensei

Ten numbered demos, one per beat of the video. Every claim the lesson makes is
something you can run.

---

## Run it

PowerShell, from this folder:

```powershell
dotnet run                # lists the demos
dotnet run -- 7           # the trap: new instead of override
dotnet run -- all         # all ten, in order
```

**A console app, deliberately.** The channel's code standard asks packages to
ship a `.http` file rather than commented-out curl — that rule is about
projects which serve requests, and this one has none. A White Belt lesson on
`virtual` should not need ASP.NET Core to run. The numbered demos are the
equivalent: each one is a clickable, runnable thing.

---

## The demos

| # | Shows |
|---|---|
| 1 | Two copy-pasted classes. The bug fixed in one and not the other |
| 2 | The base class, and how little the derived class has to say |
| 3 | Constructors are not inherited. `base(...)`, and base-runs-first |
| 4 | Every class already inherits `object` — and `ToString()` |
| 5 | The problem: a base reference calls the base method |
| 6 | `virtual` and `override`, and `base.Describe()` |
| 7 | **The trap.** `new` instead of `override` — one object, two answers |
| 8 | `abstract`, and `sealed override` |
| 9 | **The classic bug.** A virtual call from a constructor |
| 10 | The payoff: one `List<Drill>`, one loop, four behaviours |

---

## What each file is for

```
Drills/
  Drill.cs                    the base — protected, virtual, ToString override
  FormsDrill.cs               the smallest possible derived class
  SparringDrill.cs            the one that calls base.Describe()
  ConditioningDrill.cs        a third, so polymorphism has three answers
  HidingDrill.cs              DO NOT COPY — `new` instead of `override`
  BeltTestDrill.cs            three levels deep, and `sealed override`
Abstractions/
  Exercise.cs                 abstract class, abstract method, shared concrete method
  PushUps.cs, Squats.cs       they must answer, so they do
Duplication/
  *CopyPaste.cs               DO NOT COPY — the before, kept runnable
Traps/
  SummaryAtConstructionDrill.cs   DO NOT COPY — virtual call in a constructor
  BrokenSummaryDrill.cs           the subclass it bites
snippets/                     one file per still in the video, excluded from the build
```

### The three shapes we argue against are all runnable

`FormsSessionCopyPaste`, `HidingDrill` and `BrokenSummaryDrill` are real,
compiled and reachable from the demo list. That is deliberate: the lesson
compares real output rather than asking you to take its word. Every one of them
carries a `DO NOT COPY THIS SHAPE` comment at the top.

### Why warnings are not errors here

Demo 7 exists to show what the compiler says when you hide a base method
without saying `new`. `TreatWarningsAsErrors` is off in the `.csproj` so that
warning stays visible instead of stopping the build.

---

## The five words that do the work

| Word | What it actually means |
|---|---|
| `: Base` | start as one of those, then add |
| `protected` | my family may read this; nobody else may |
| `virtual` | a subclass is allowed to replace this |
| `override` | I am replacing it, and my version runs even through a base reference |
| `abstract` | there is no sensible default — you must supply one |
| `sealed` | this is the final answer; nothing below may change it again |
| `new` | I am hiding it, not replacing it. **Almost always a mistake** |

---

## This week's drill

Find two classes in your own code that share more than half their lines.

1. Write down what is genuinely the same. If it is only the *fields*, stop —
   that is not inheritance, that is a shared record.
2. If they share **behaviour**, and one really is a kind of the other, pull the
   shared part into a base class and make the differing method `virtual`.
3. Then check the sentence out loud: "a `FormsDrill` is a `Drill`." If it makes
   you hesitate, use composition instead — hold the other object rather than
   inheriting from it.

The test is not "do these share code". It is "is one of them a kind of the
other", and those are different questions.

---

MIT. Part of the C# Sensei course: https://github.com/csharpsensei/csharp-sensei
