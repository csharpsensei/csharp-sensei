# L011: Locking It Down, Then Unlocking Polymorphism

Code for **V011: Locking It Down, Then Unlocking Polymorphism** (⬜ White
Belt). MIT licensed, same as the rest of the repo.

```powershell
dotnet run
```

## What it shows

`Program.cs` is the **composition root**. It runs five passes:

1. the naive if/else version from the hook (`Legacy/NaiveDispatch.cs`), the
   thing this lesson replaces
2. `Device d = new Tv(...)`, then `d = new Soundbar(...)`, the same call,
   `d.Power()`, producing two different results
3. a fourth device, `SmartSpeaker`, added with zero changes to anything
   above it
4. a `List<Device>` holding all three, walked with one `foreach`
5. a `sealed` device, `BluRayPlayer`, added to the same list, working
   exactly as every other device does

## Layout

| File | Why it exists |
|---|---|
| `Legacy/NaiveDispatch.cs` | the "before": an enum and an if/else chain, demoed once and abandoned |
| `Devices/Device.cs` | the base class, one `virtual` method |
| `Devices/Tv.cs`, `Devices/Soundbar.cs`, `Devices/SmartSpeaker.cs` | three overrides, three different bodies |
| `Devices/BluRayPlayer.cs` | overrides `Power`, and is `sealed` |

One public type per file, folders by role (`PRODUCTION-SYSTEM.md` §16.2).

## The rejected shape

`snippets/v011-12b2-1-sealed-error.cs` is `ExtendedBluRayPlayer : BluRayPlayer`,
deliberately not valid C# (CS0509). It is excluded from the real build via
`snippets/**` in `L011.csproj`, the same mechanism that keeps every lesson's
read-along files out of compilation. DO NOT COPY it into `Devices/`; it will
break the build on purpose.

## Simplifications, named rather than hidden

- **No dependency injection, no interfaces.** This lesson is about a base
  class reference and `virtual`/`override`; introducing `IDevice` here would
  put V010's lesson back on screen when the point is a different one.
- **`Name` is the only state a device carries.** A real smart-home app would
  have a lot more; more fields would not teach polymorphism any better.

## Verified by running

`dotnet build` / `dotnet run` confirmed working in Rider on 13 August 2026 —
exit code 0, console output matched the `snippets/*-output.cs` stills
exactly. (No .NET SDK was reachable in the generation sandbox, so this could
not be checked there; same standing caveat as V009 and V010 at generation
time — closed for this lesson now that it has actually been run.)

## The drill

Take a base class you have written with one `virtual` method. Add a second
override. Call it only through a variable typed as the base class, the way
the `Device` list here does, and watch the same call produce two different
results.
