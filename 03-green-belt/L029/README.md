# L029, Component Tests in C#

🟩 Green Belt · combo G-T2, component tests · 🟩 Green Belt Testing and Code
Quality playlist.
Video: C# Sensei. Code is MIT.

## Run it

This project is an xUnit v3 test project, which is an executable, so
`dotnet run` runs the tests.

```powershell
dotnet run
```

That runs every real test and should report no failures. The lesson runs the
two kinds one at a time, and the one test that fails on purpose on its own:

```powershell
dotnet run -- -trait "Kind=Unit"
dotnet run -- -explicit only -class "*BrokenBookingTests"
dotnet run -- -trait "Kind=Component"
```

## What is in it

| Folder | What is in it |
|---|---|
| `App/Booking/` | `BookingService`, the front door of the booking component, and its request and result |
| `App/Pricing/` | `TicketPricer`, nine pounds a seat, and `StudentDiscount`, twenty percent off |
| `App/Ports/` | The three edges: seats, payment and confirmation, as interfaces |
| `Tests/Unit/` | Four unit tests, each class on its own |
| `Tests/Component/` | Four component tests, the whole component through `Book`, with stand ins only at the edges |
| `Tests/Fakes/` | The three stand ins, written by hand. No mocking library |
| `Regression/` | The booking service with one line wrong, and the explicit test that catches it |

**Every test is Arrange, Act, Assert, marked with a comment, always.** One Act
per test, named method, scenario, expected result.

## The code that is deliberately wrong, and where

`Regression/BrokenBookingService` carries `DO NOT COPY THIS SHAPE`. It takes the
discount's percentage away as if it were pence, so two student seats cost
seventeen pounds eighty instead of fourteen pounds forty. Every class it uses
passes its own unit tests, which is the point. Its test is explicit, so a plain
`dotnet run` stays green.

## Simplifications, named rather than hidden

- **One project, not two.** A real solution keeps the application and its tests
  in separate projects.
- **No `Program.cs`, no `.http` file and no real database, payment provider or
  email service.** xUnit supplies the entry point, and the three edges exist
  here only as interfaces and stand ins, because the lesson is about the
  component between them.
- **The stand ins are written by hand.** Mocking libraries do the same job with
  less typing, and are a subject of their own.

## This week's drill

Pick one feature in your own code that uses three or more classes together.
Write one component test that calls it through its front door, with stand ins
only where it touches the outside world, and check the result a user would see.
