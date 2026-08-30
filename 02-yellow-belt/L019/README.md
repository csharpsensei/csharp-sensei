# L019: LINQ Basics, Where, Select and Your First Query

Companion code for **V019** on the C# Sensei channel. 🟨 Yellow Belt.

Run it:

```powershell
dotnet run --project L019.csproj
```

It prints three passes over the same twelve job applications:

1. **The shortlist, written as a loop.** `Legacy/HandRolledSift.cs`. It reports
   how many applications it examined, because the loop is the thing doing the
   walking, so the walking is a number it can count.
2. **The same shortlist, written as a query.** `Sifting/Shortlist.cs`. One call
   to `Where`. It prints whether it produced the same four people in the same
   order as the loop did.
3. **The contact sheet.** `Sifting/ContactSheet.cs`. `Where` then `Select`, so
   what comes back is no longer applications at all.

## The two verbs

| Verb | What it does to the count | What it does to each item |
|---|---|---|
| `Where` | Changes it. Keeps some, drops the rest | Nothing at all |
| `Select` | Leaves it alone | Changes what each one is |

## Deliberate simplifications, named rather than hidden

`PRODUCTION-SYSTEM.md` §16.3: on-screen code follows the practice we would
recommend, or it says why it does not.

- **Twelve applications, not two hundred.** The pile is small so that every row
  the program prints can be read on screen and checked by hand against the data.
  Nothing in the lesson depends on the size.
- **The data is a static list, not a database.** Where the rows come from is a
  different lesson. `IEnumerable<Candidate>` is the only thing any of the sifting
  code knows about them.
- **Every phone number is inside Ofcom's reserved 07700 900000 to 07700 900999
  drama range**, which can never be allocated to a real person. No real contact
  details appear in this repo.
- **The filter is on skills only.** Never on age, and never on years of
  experience. A teaching example should not model a sift that a real hiring pile
  could not lawfully use, and skills give the more useful example anyway: two
  conditions, so `&&` inside the lambda arrives because the question needs it.

## What is deliberately NOT here

- **Deferred execution.** When the query actually runs is its own lesson. This
  code calls `.ToList()` in pass 2 only so the two shortlists can be compared,
  and the video does not discuss why that line is there.
- **Query syntax.** `from candidate in pile where ... select ...` is a second way
  to write the same thing, and it is its own lesson too. Everything here is
  method syntax.
- **The cost of `Contains`.** `Candidate.Has` uses it, and choosing between a
  list and a dictionary is already covered in V006.
