# L032, What's New in C# 15 and .NET 11

🟫 Brown Belt · combo AN-1, the first announcement explainer.
Video: C# Sensei. Code is MIT.

## You need the .NET 11 SDK

This project targets `net11.0`. At the time of writing that is release
candidate 1, SDK `11.0.100-rc.1`, from dotnet.microsoft.com. Microsoft's RC1
release notes say C# 15 is selected by default for `net11.0`, so the project
sets no `LangVersion`.

## Run it

```powershell
dotnet run -- unions
dotnet build -p:ShowMissingCase=true
dotnet run -- more
```

A plain `dotnet run` runs both demos. A plain `dotnet build` has no warnings.

## What is in it

| Folder | What is in it |
|---|---|
| `Payments/` | The three case records, the `PaymentResult` union, a pretend `CardGateway`, and `PaymentMessages`, the exhaustive switch |
| `Before/` | The order status as it was written before C# 15: an abstract base and a switch that needs a discard arm |
| `Orders/` | The same order status as a C# 15 closed hierarchy, and the switch with no discard arm |
| `Extensions/` | `SequenceIndexer`, a C# 15 extension indexer |
| `Demos/` | `UnionDemo` and `MoreDemo`, which print what the lesson shows |
| `Regression/` | A fourth case added to the union and a switch that misses it, compiled only with `-p:ShowMissingCase=true` |

## The code that is deliberately wrong, and where

`Regression/MissingCaseMessages` carries `DO NOT COPY THIS SHAPE`. Its switch was
written before `Refunded` existed and was never updated, so the compiler warns
that it is not exhaustive. It is left out of a normal build so the project
builds clean.

`Before/OrderMessages` is the old shape on purpose: the discard arm that throws
is what the lesson argues against.

## Simplifications, named rather than hidden

- **`CardGateway` is pretend.** A real gateway calls the bank. This one decides
  from the amount so the lesson can show all three results.
- **The extension indexer walks the sequence every time.** `ElementAt` on a
  plain `IEnumerable<string>` starts from the beginning on every use, so it is
  shown for the syntax, not as a fast way to index. Use a list when you index
  in a loop.
- **Release candidate.** Everything here was checked against Microsoft's notes
  on 6 October 2026, with .NET 11 at RC1. Check the current notes before you
  rely on it.

## This week's drill

Find one switch in your code that ends in a discard arm that throws. Write down
every case it really handles, and ask whether a union or a closed hierarchy
would let the compiler check it for you.
