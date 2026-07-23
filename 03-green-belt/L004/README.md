# 004 — Dependency Injection

🟩 **Green Belt** · Design Patterns

Covers dependency injection, when a factory beats injection, and the service
locator anti-pattern.

**Video**: _(link once published)_

---

## Run it

```bash
dotnet run
```

Seven sections print in order:

1. **The bad smell** — a class that constructs its own dependencies, and the
   exception you get when you try to exercise it.
2. **The fix** — constructor injection wired through a single composition root,
   with `ValidateOnBuild` and `ValidateScopes` turned on.
3. **Testability** — the same class built with hand-written fakes, no network.
4. **Factory vs DI** — three payment gateways chosen per order at runtime,
   from a consumer holding exactly one dependency.
5. **Service locator** — the same missing registration failing twice: once
   deep inside a method, and once at startup where it belongs.
6. **Lifetimes** — singleton, scoped and transient resolved twice across two
   scopes, printing object identity so you can see exactly what each one
   shares, plus scope disposal.
7. **Many implementations** — three validators behind one interface, consumed
   as `IEnumerable<T>`, with `GetServices`, `GetRequiredService` (returns the
   *last* registration) and `TryAddEnumerable` demonstrated.

Requires the .NET 10 SDK. If `Microsoft.Extensions.DependencyInjection 10.0.0`
doesn't restore, bump the version in the `.csproj` to match your SDK.

---

## Files

| File | What it is |
|---|---|
| `Program.cs` | The runnable walkthrough |
| `Dojo.cs` | Interfaces, implementations, fakes and the anti-pattern |
| `snippets/` | One `.cs` file per code screenshot in the video — read-along, excluded from the build |

The `snippets/` folder is excluded via `DefaultItemExcludes` and included as
`None` items. If Rider ever injects a `<Compile Include="snippets\...">` line
into the `.csproj`, delete it — it breaks the exclusion and causes CS8802.

---

## The one-sentence version

**A constructor should be able to tell you everything a class touches.**

If it's empty and the real dependencies are pulled out of a container inside
the methods, that's a service locator wearing a DI badge — and you've given up
the compiler, the tooling, the tests and the startup check.

---

## This week's drill

Find one class in your own codebase that calls `new` on a service it depends
on. Extract an interface, move it to the constructor, register it once at
startup. Then write the unit test that was impossible yesterday.

One class. The second one goes much faster.

---

## Rule of thumb

| Situation | Reach for |
|---|---|
| The choice is known at startup | Inject the dependency |
| The class needs one known variant of an interface | Keyed services, `[FromKeyedServices]` |
| You need **every** implementation of an interface | Inject `IEnumerable<T>` |
| The choice depends on data you only have at runtime | Inject a factory |
| A singleton needs scoped work | Inject `IServiceScopeFactory`, scope per unit of work |
| Anything else reaching into the container | Almost certainly a service locator |

## Lifetimes

| Lifetime | Instances | Reach for it when | Examples |
|---|---|---|---|
| `AddSingleton` | One, forever | Stateless, or genuinely global state, and expensive to build | `IClock`, `IEmailSender`, `IMemoryCache` |
| `AddScoped` | One per scope (per request in ASP.NET Core) | It carries the state of one unit of work | `DbContext`, `IUnitOfWork`, `ICurrentUser` |
| `AddTransient` | One per resolution | Cheap and stateless; sharing gains nothing | validators, renderers |

Two traps:

- A **captive dependency** — a scoped or transient service injected into a
  singleton is captured for the life of the process. Turn on `ValidateScopes`
  and the container refuses to start.
- Transients resolved from the **root** provider are tracked and not released
  until shutdown. Resolve from a scope.

## Registration verbs

| Verb | Behaviour |
|---|---|
| `Add*` | Always adds. Several registrations of one interface are legal |
| `TryAdd*` | Adds only if nothing is registered for that service type |
| `TryAddEnumerable` | Adds only if that *implementation type* is absent — stops double registration |
| `Replace` | Swaps the registration for a service type |
| `RemoveAll` | Clears every registration for a service type |

`GetRequiredService<T>` with several registrations returns the **last** one
registered. `GetServices<T>` returns all of them, in registration order.

Keyed registrations are a separate world: they do not appear in a plain
`IEnumerable<T>` and are not found by a plain `GetRequiredService<T>`.

MIT licensed, same as the rest of the repo.
