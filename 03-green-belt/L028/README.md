# L028, Unit Testing in C#: Your First Test, and Names That Explain

🟩 Green Belt · combo G-T1, unit tests in depth · 🟩 Green Belt Testing and
Code Quality playlist.
Video: C# Sensei. Code is MIT.

## Run it

This project is an xUnit v3 test project, which is an executable, so
`dotnet run` runs the tests.

```powershell
dotnet run
```

That runs the six real unit tests and should report no failures. The three
tests that fail on purpose are explicit, so a plain run skips them. The lesson
runs each one on its own:

```powershell
dotnet run -- -explicit only -class "*BadlyNamedTests"
dotnet run -- -explicit only -class "*WellNamedTests"
dotnet run -- -explicit only -class "*SwappedArgumentsTests"
```

## What is in it

| Folder | What is in it |
|---|---|
| `App/` | `LateFeeCalculator`: twenty pence a day late, capped at five pounds |
| `Tests/` | Six unit tests, one behaviour each, named method, scenario, expected result |
| `Regression/` | A calculator that lost its cap, three explicit tests that fail against it, and a calculator that reads the clock |

**Every real test is Arrange, Act, Assert, marked with a comment, always.** One
Act per test. `xunit.runner.json` sets `methodDisplay` to `method`, so the
runner prints each test's name on its own.

## The code that is deliberately wrong, and where

Each one carries `DO NOT COPY THIS SHAPE` in its doc comment.

- `Regression/BrokenLateFeeCalculator` has lost the five pound cap.
- `Regression/BadlyNamedTests` is called `Test1`, acts three times and checks
  with `Assert.True`. It is the only test in the project that is not Arrange,
  Act, Assert, because it is the example of what that shape prevents.
- `Regression/SwappedArgumentsTests` passes the actual value where the expected
  one belongs, so its failure message is backwards. **The build shows an xUnit
  analyzer warning for it, xUnit2000. That warning is expected.** The build may
  also suggest a better assertion for `Test1`; that is expected too.
- `Regression/ClockBoundLateFeeCalculator` reads `DateTime.Today` inside the
  method. It has no test, because any test of it would depend on the day it ran.

## Two simplifications, named rather than hidden

- **One project, not two.** A real solution keeps the application and its tests
  in separate projects. This one keeps both so the lesson is one folder and one
  command.
- **No `Program.cs` and no `.http` file.** xUnit v3 supplies the entry point,
  and there is no web app to send requests to.

## This week's drill

Find one test in your own code, or write one, and rename it in three parts:
the method, the scenario, the expected result. If you cannot name it that way
without the word "and", split it into two tests.
