# L033, The Adapter Pattern in C#: Making Someone Else's Shape Fit

🟩 Green Belt · combo G-P6 · design pattern P2.2 Adapter.
Video: C# Sensei. Code is MIT.

Run it:

```powershell
dotnet run
```

Five passes print, in the order the lesson argues them:

| Pass | What it shows |
|---|---|
| 1 | Our heating plan calling a supplier's controller directly, Fahrenheit sums and all |
| 2 | The same plan through `HeatwiseThermostat`, the adapter, and the rounding it has to do |
| 3 | A second supplier, a second adapter, and the plan unchanged |
| 4 | Both suppliers asked for 32 C: one refuses, in our terms, and one accepts |
| 5 | The plan tested against a fake, with no supplier code at all |

Numbers are formatted with the invariant culture, so the output is the same on
any machine.

## The layout

| Folder | What is in it |
|---|---|
| `Heating/` | Ours: `IThermostat`, `ComfortPlan`, `TargetRejectedException`, and the two adapters |
| `Vendor/` | Theirs: `HeatwiseController` and `ThermoLinkDevice`, standing in for supplier SDKs we cannot edit |
| `Legacy/` | Two deliberately wrong shapes, both marked `DO NOT COPY THIS SHAPE` |
| `Testing/` | `FakeThermostat`, a hand-written fake |
| `Reporting/` | Console formatting only |

## Simplifications, named

- **The supplier classes are simulated in memory.** A real SDK would talk to a
  device. The lesson is about the shape of the boundary, not the hardware.
- **`Legacy/CoupledComfortPlan`** is the hook's bad smell: our logic doing
  Fahrenheit sums and reading status codes. Do not copy it.
- **`Legacy/OpinionatedThermostat`** is mistake one: a heating rule living
  inside an adapter. No pass runs it. Do not copy it.

## This week's drill

Find one place in your own code where a third-party type's names or units
appear in more than one file, and move every one of them behind a single class
that implements an interface you wrote.
