# L037, Facade in C#: One Door Into a Complicated Room

🟩 Green Belt · combo G-P8 · design pattern P2.6 Facade.
Video: C# Sensei. Code is MIT.

Run it:

```powershell
dotnet run
```

| Pass | What it shows |
|---|---|
| 1 | Two callers doing the publishing steps by hand, and one of them missing a step |
| 2 | Both callers through `ArticlePublisher`, the facade: the same four steps, in order |
| 3 | An admin tool using one subsystem directly, because a facade is not a wall |
| 4 | A draft that fails proofreading: the facade stops before the later steps |

Every subsystem writes the step it ran into a journal, so a pass can print
exactly what each caller did.

## The layout

| Folder | What is in it |
|---|---|
| `Publishing/` | The four subsystems, `Draft`, `PublishResult`, and `ArticlePublisher`, the facade |
| `Callers/` | The button and the scheduled job after the change, and `ReindexTool` |
| `Legacy/` | The two callers before the change, both `DO NOT COPY THIS SHAPE` |
| `Reporting/` | Console helpers and the two fixed drafts |

## Simplifications, named

- **The subsystems record their step instead of doing real work.** The lesson
  is about who knows the steps, not about resizing images.
- The two `Legacy/` callers are the hook. Do not copy them.

## This week's drill

Find one sequence of three or more calls that appears in two places in your own
code, and give it one method with a name, in one class, that both places call.
