# L024 — The Builder Pattern

Run it:

```
dotnet run --project code\L024\L024.csproj
```

Three passes, and each one prints what it proves.

## Pass 1 — ten arguments, and nothing holding them apart

`Positional/PositionalBooking.cs` takes ten constructor parameters, and four of
them sit beside a parameter of their own type: two `DateOnly` values, then two
`int` values. The pass builds the same booking three times, changing only the
order of two arguments each time. All three compile. Two of them are bookings
nobody meant, and one of those has a negative number of nights in it.

## Pass 2 — one named step at a time

`Fluent/BookingBuilder.cs` names every value as it arrives and checks nothing
until `Build()`. Three of its rules cannot be checked one property at a time:

- departure has to be after arrival, which needs both dates,
- the guests have to fit the room, which needs the counts and the room type,
- a cot needs a child on the booking, which needs both.

`Build()` collects every problem and throws one `InvalidOperationException`
carrying all of them, rather than stopping at the first.

## Pass 3 — what the language already does

`Modern/InitBooking.cs` is the same booking as required members with `init`
accessors. The compiler will not let a caller forget a required value, and
every value is named at the call site, so most of what a builder was invented
for is already in the language. What an object initialiser cannot do is look at
two properties together, so it builds the version with the dates the wrong way
round without a word. The builder, handed the same two dates, refuses.

## The one thing to notice in the code

`Build()` passes `_requests.ToArray()` into the booking rather than the list it
has been collecting into. Hand the list itself over and anything added to the
builder afterwards would turn up inside a booking that was already finished.

## Simplifications, named rather than hidden

- Prices, availability and any real hotel system are out of scope. The booking
  is a value object and nothing here talks to a database.
- `RoomCapacity` is a static lookup with no state of its own.
