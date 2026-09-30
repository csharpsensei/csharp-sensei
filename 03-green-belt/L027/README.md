# L027, Testing in C#: Why We Test, and the Test Pyramid Explained

🟩 Green Belt · combo G-T0, the testing opener · first lesson in the
🟩 Green Belt Testing and Code Quality playlist.
Video: C# Sensei. Code is MIT.

## Run it

This project is an xUnit v3 test project, which is an executable, so
`dotnet run` runs the tests.

```powershell
dotnet run
```

That runs every test and should report no failures. The lesson runs the three
kinds of test one at a time, so their counts and times can be compared:

```powershell
dotnet run -- -trait "Kind=Unit"
dotnet run -- -trait "Kind=Integration"
dotnet run -- -trait "Kind=EndToEnd"
```

And the one test that fails on purpose, the regression from the start of the
lesson:

```powershell
dotnet run -- -explicit only
```

## What is in it

| Folder | What is in it |
|---|---|
| `App/` | The application: `PostageCalculator`, the quote records, `JsonQuoteStore`, and `PostageApi`, two HTTP endpoints |
| `Tests/Unit/` | Six unit tests. The calculator on its own, nothing else |
| `Tests/Integration/` | Two integration tests. The store against a real folder and the real JSON serialiser |
| `Tests/EndToEnd/` | One end to end test. The whole app on a real port, over real HTTP, saving to a real disk |
| `Regression/` | The calculator after a tidy up that broke it, and the explicit test that catches it |

Six, two, one. The counts are the test pyramid on purpose.

**Every test is Arrange, Act, Assert, marked with a comment, always.** One Act
per test. Every test is named method, situation, expected result, so a failure
explains itself. `xunit.runner.json` sets `methodDisplay` to `method`, so the
runner prints that name on its own.

## The code that is deliberately wrong, and where

`Regression/TidiedPostageCalculator` carries a doc comment saying
`DO NOT COPY THIS SHAPE`. Both less-than-or-equals became less-than, so a
parcel of exactly one kilo is charged the medium rate. It exists so the lesson
can show a test catching a regression without the repository's own tests going
red, which is why its test is explicit.

## Three simplifications, named rather than hidden

- **One project, not two.** A real solution keeps the application and its tests
  in separate projects. This one keeps both so the lesson is one folder and one
  command.
- **No `Program.cs` for the application.** xUnit v3 supplies the entry point.
  `PostageApi.Build` is the wiring a real app's `Program.cs` would do, and the
  end to end test calls it. For the same reason there is no `.http` file: there
  is no standalone app to send requests to.
- **xUnit1051 is switched off in the project file.** It asks every async call in
  a test to pass the test's cancellation token, which is right for a large suite
  and noise on screen for a first look at tests.

## What is not here, and is in the lesson

Component, automated UI, load, stress, smoke, soak, spike and contract tests are
explained in the video and not run here.

## This week's drill

Pick one method in your own code that makes a decision. Write one unit test for
it: Arrange, Act, Assert, named so a stranger knows what broke from the name
alone.
