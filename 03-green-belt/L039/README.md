# L039, Proxy in C#: Standing In Front of the Real Thing

🟩 Green Belt · combo G-P9 · design pattern P2.8 Proxy.
Video: C# Sensei. Code is MIT.

Run it:

```powershell
dotnet run
```

| Pass | What it shows |
|---|---|
| 1 | The real archive created at start-up, though nothing reads it |
| 2 | The same start behind `LazyArchiveProxy`: opened only on the first read, once |
| 3 | `GuardedArchiveProxy` in front of the lazy one: one read allowed, one refused, and the refused one never opens anything |

## Simplifications, named

- **`DiskArchive` does not touch a disk.** Its constructor records that it was
  opened, so the passes can count. In a real system that constructor is the
  expensive part: storage, an index, a connection.
- **`LazyArchiveProxy` is not thread safe.** Two threads reading at once could
  both open the archive. `Lazy<T>` handles that, and the video says so.
- **Roles are a string array on a record.** Real authorisation comes from the
  framework; the lesson is about where the check stands, not how roles work.

## This week's drill

Find one object in your own code that is created at start-up but only used on
some requests, and put a proxy, or a `Lazy<T>`, in front of it.
