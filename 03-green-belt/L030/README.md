# L030, Integration Tests in C#

🟩 Green Belt · combo G-T3, integration tests · 🟩 Green Belt Testing and Code
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
dotnet run -- -explicit only -class "*BrokenMemberStoreTests"
dotnet run -- -trait "Kind=Integration"
```

The integration tests create real SQLite database files in your temp folder,
one per test, and delete each one when its test finishes.

## What is in it

| Folder | What is in it |
|---|---|
| `App/Members/` | `Member`, the `IMemberStore` edge, `EmailAddress`, `SignUpService`, and `SqliteMemberStore`, the real store |
| `Tests/Unit/` | Two unit tests for the email rule |
| `Tests/Component/` | Two component tests for sign up, with a stand in for the database |
| `Tests/Fakes/` | `FakeMemberStore`, written by hand. No mocking library |
| `Tests/Integration/` | Three integration tests: the real store against a real SQLite database |
| `Regression/` | The store with one line wrong, and the explicit test that catches it |

**Every test is Arrange, Act, Assert, marked with a comment, always.** One Act
per test, named method, scenario, expected result.

## The code that is deliberately wrong, and where

`Regression/BrokenSqliteMemberStore` carries `DO NOT COPY THIS SHAPE`. Its
SELECT asks for the email first and the name second, and its mapping still
reads them the other way round. Both columns are text, so it compiles, runs and
returns Sam Lee with the name and the email swapped. Every unit and component
test passes, because none of them runs the SQL. Its test is explicit, so a
plain `dotnet run` stays green.

## Simplifications, named rather than hidden

- **One project, not two.** A real solution keeps the application and its tests
  in separate projects.
- **No `Program.cs` and no `.http` file.** xUnit supplies the entry point, and
  the lesson is about the store, not an API in front of it.
- **SQLite is the real database here.** The tests use the same engine the store
  is written for. If your application ships on a different database, test
  against that one.
- **Synchronous data access.** Microsoft's Microsoft.Data.Sqlite documentation
  says SQLite has no asynchronous I/O and the async methods run synchronously,
  so it advises against calling them.
- **`Pooling=False` in the tests' connection string,** so each connection really
  closes and the database file can be deleted afterwards.

## This week's drill

Pick one place your code writes to a database or a file. Write one integration
test that writes through your real code, reads it back with a fresh instance,
and checks you get back exactly what you put in.
