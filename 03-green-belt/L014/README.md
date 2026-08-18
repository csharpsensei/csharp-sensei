# L014: Liskov Substitution, When a Subclass Lies

🟩 Green Belt · SOLID, third letter · C# Sensei

Run it:

```powershell
dotnet run
```

Three passes print to the console, one per cycle of the lesson. The caller is
the same class in passes 1 and 2. Only the subclasses change, and that is the
whole argument.

## The contract

`Notifications/Notifier.cs` carries it, in words, above the class:

- **Accepts** any recipient, and any message of one character or more.
- **Returns** a `Receipt` whose `Delivered` flag is true only if the message
  reached the recipient.
- **Throws** nothing for a message the contract accepts.

Two rules come out of that, and they are the whole lesson. A subclass may not
**demand more** than the base demands. A subclass may not **deliver less**
than the base promises.

## What is in here

| Folder | What it is |
|---|---|
| `Notifications/` | The contract, and the two subclasses that keep it. `AlertService` is the caller, and it is byte for byte the same before and after the refactor. |
| `Legacy/` | **The violation. DO NOT COPY.** `LyingSmsNotifier` throws for anything over 160 characters, which demands more than the base does. `SilentAuditNotifier` returns `Delivered: true` without sending anything, which delivers less than the base promises. Kept runnable so the lesson can show both failing. |
| `Auditing/` | What `SilentAuditNotifier` became once it stopped pretending: a plain class with no base type. It cannot keep the contract, so it is not a subtype. There is no override that would have fixed it. |
| `OverGeneral/` | **The boundary. DO NOT COPY.** A base class whose `Send` returns `void` and promises nothing. Every subclass is substitutable, and every caller has to type check to find out what it actually got. |
| `snippets/` | One read-along file per rendered still, sharing that still's ID. Excluded from the build. |

## The drill

Find an override in your own code that throws, returns null, or does nothing
at all. Write down what the base said that method would do. If the two
disagree, you have found one, and you get to decide which of the two is
wrong: the subclass, or the promise the base made.

## Three things stated rather than hidden

1. **Nothing is actually sent.** `EmailNotifier` and `SmsNotifier` do not
   call an SMTP client or an SMS gateway. The simplification is named in a
   comment in each file. It means the project runs with no account, no
   credentials, and nothing secret anywhere in the repo
   (`PRODUCTION-SYSTEM.md` §16.3).
2. **`LegacyAlertRun` has a `try`/`catch` and a real caller would not.** It
   is there so pass 1 can carry on past the failure and show the rest of the
   pass. It prints the exception type and message rather than swallowing
   anything. Needing that catch at all is the bug the lesson is about.
3. **`OverGeneral/` puts four types in one file**, which
   `PRODUCTION-SYSTEM.md` §16.2 says not to do. It is the only deviation in
   this project and it is deliberate: the point of that example is how little
   each of those types says, and spreading four near-empty classes across
   four files hides exactly that.

## A real one, in the framework you already use

In .NET, a single dimensional array implements `IList<T>`. Cast an array to
that interface and call `Add`, and you get a `NotSupportedException` every
time, by design. Microsoft's own documentation for `System.Array` says so:
members that add, insert or remove elements throw. A type that says it is a
list, and refuses the one thing a list is for.

<https://learn.microsoft.com/en-us/dotnet/api/system.array>
