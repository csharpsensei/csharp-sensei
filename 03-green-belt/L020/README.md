# L020 — Abstract Factory in C#

Run it:

```
dotnet run --project L020.csproj
```

Three passes, all drawing the same settings screen:

1. **`Legacy/HandBuiltScreen.cs`** — the heading, the button and the caption are
   each chosen on their own line. High contrast reached two of the three. The
   program prints `Parts agree: False` and you can see the light button sitting
   under a high-contrast heading.
2. **`Screens/SettingsScreen.cs` with one theme** — the same screen, asked of
   one `IScreenTheme`. `Parts agree: True`, and there is no combination of
   parts this code could have asked for that would not match.
3. **The same call site, both themes** — nothing in `SettingsScreen` differs
   between the two runs.

## Simplifications named rather than hidden

- **The parts draw text, not pixels.** A real theme sets colours, fonts and
  spacing. Text keeps every character on screen readable and keeps the lesson
  about the pattern rather than about a UI toolkit.
- **`Style` exists so the lesson can prove agreement at runtime.** Production
  parts would not carry a string naming their own family; if yours do, and code
  branches on it, that is mistake two in the video.
- Three parts is the smallest number that shows a family. Real families run to
  a dozen, which is exactly where this pattern's own cost lands.
