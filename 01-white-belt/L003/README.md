# 003 — Properties and Fields ⬜ White Belt

Lesson code for the C# Sensei video *Properties and Fields*.

Run it:

```bash
dotnet run --project 003-properties-and-fields.csproj
```

## The drill

Open your own codebase and find one public field on a class that outlives a
single method. Turn it into a property. Then find one property that does real
work in its getter, and turn that into a method. Two changes, ten minutes.

## `snippets/`

One file per rendered code screenshot in the block 7 (mistakes) section.
These are the exact sources of the PNGs in `Assets/`, kept as read-along
files. They are excluded from the build via `DefaultItemExcludes` — they are
fragments, not compilable units, and several deliberately show the *wrong*
way to do something.

| File | Screenshot | Point |
|------|-----------|-------|
| `7a-public-field.cs` | `v003-code-7a-public-field.png` | Public fields give away control |
| `7a-property-fix.cs` | `v003-code-7a-property-fix.png` | Properties keep it |
| `7b-ceremony.cs` | `v003-code-7b-ceremony.png` | Backing field that earns nothing |
| `7b-auto-property.cs` | `v003-code-7b-auto-property.png` | The same thing, one line |
| `7c-heavy-getter.cs` | `v003-code-7c-heavy-getter.png` | Real work hidden in a getter |
| `7c-method-fix.cs` | `v003-code-7c-method-fix.png` | Make it a method so callers know |
| `7d-mutable-collection.cs` | `v003-code-7d-mutable-collection.png` | Get-only, still mutable |
| `7d-leak.cs` | `v003-code-7d-leak.png` | The leak in action |
| `7d-readonly-view.cs` | `v003-code-7d-readonly-view.png` | Hand out a read-only view |

## Note on `Program.cs` vs the screenshots

`Program.cs` is a single runnable file, so the mistake and fix versions of
each class live in `PropertiesAndFields.Mistakes` and
`PropertiesAndFields.Fixed` rather than colliding on one name. It also
initialises a couple of strings (`= string.Empty;`) that the screenshots omit,
because the project has `<Nullable>enable</Nullable>` and the screenshots are
trimmed to the one idea on screen. The snippet files match the PNGs verbatim.

## ⚠️ Rider gotcha (already solved — do not re-debug)

If Rider auto-injects `<Compile Include="snippets\..." />` into the `.csproj`
after adding a file through its UI, **delete that line immediately**. It
silently defeats the exclusion and produces CS8802 (duplicate top-level
statements).
