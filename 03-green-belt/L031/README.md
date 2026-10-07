# L031, End to End Tests in C#

🟩 Green Belt · combo G-T4, end to end tests · 🟩 Green Belt Testing and Code
Quality playlist.
Video: C# Sensei. Code is MIT.

## Run it

This project is an xUnit v3 test project, which is an executable, so
`dotnet run` runs the tests.

```powershell
dotnet run
```

That runs every real test and should report no failures. The lesson runs the
kinds one at a time, and the one test that fails on purpose on its own:

```powershell
dotnet run -- -trait "Kind=Component"
dotnet run -- -explicit only -class "*BrokenWiringTests"
dotnet run -- -trait "Kind=EndToEnd"
```

The end to end tests start the real application on port 0, which asks the
operating system for any free port, and stop it when each test finishes.

## What is in it

| Folder | What is in it |
|---|---|
| `App/Bookings/` | `Booking`, `BookingRequest`, the `IBookingStore` edge, `InMemoryBookingStore` and `BookingService` |
| `App/` | `RepairShopEndpoints`, the two endpoints, and `RepairShopApi`, the wiring |
| `Tests/Component/` | Two component tests: the booking service with the real store |
| `Tests/EndToEnd/` | Three end to end tests: the whole app, over real HTTP |
| `Tests/Wiring/` | One fast test pushed down after the end to end test found the bug |
| `Regression/` | The app with one line of wiring wrong, and the explicit test that catches it |

**Every test is Arrange, Act, Assert, marked with a comment, always.** One Act
per test, named method, scenario, expected result.

## The code that is deliberately wrong, and where

`Regression/BrokenRepairShopApi` carries `DO NOT COPY THIS SHAPE`. It registers
the store with `AddScoped` instead of `AddSingleton`, so every request gets a
new, empty store. A booking is created, answered with 201, and is gone when the
next request asks for it. Every component test passes, because none of them
runs the wiring. Its test is explicit, so a plain `dotnet run` stays green.

## Simplifications, named rather than hidden

- **One project, not two.** A real solution keeps the application and its tests
  in separate projects.
- **No `Program.cs` and no `.http` file.** xUnit supplies the entry point, so
  the application's wiring lives in `RepairShopApi.Build`, where the tests can
  start it. In a real app that wiring is `Program.cs`.
- **An in-memory store.** A real shop keeps bookings in a database; the
  integration test for that is L030's subject. The store is thread safe because
  the real wiring shares one instance across every request.
- **`xUnit1051` is switched off** in the project file. It asks every async call
  in a test to pass the test's cancellation token: right for a large suite,
  noise on screen for a lesson.
- **The server's logging is switched off,** so its lines do not land in the
  middle of the test runner's output.

## This week's drill

Pick the one journey your application most needs to work. Write one end to end
test that starts the real application, goes in through the front door, and
checks what comes back out.
