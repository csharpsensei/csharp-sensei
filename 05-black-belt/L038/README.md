# L038, Microservices vs Monolith in .NET, and the API Gateway

⬛ Black Belt · combo BK-C1 · E3.2 Monolith vs Microservices and E3.9 API
Gateway, with E3.1 Microservices Intro absorbed into the opening.
Video: C# Sensei. Code is MIT.

Run it:

```powershell
dotnet run
```

| Pass | What it shows |
|---|---|
| 1 | The monolith: one page, two modules, two ordinary method calls |
| 2 | The same two jobs as two services, each called at its own address |
| 3 | Both services through one gateway: one address for the client |
| 4 | The stock service stopped: the catalog still answers, stock gets a 503 |

Pass 4 can pause for a second or two while the connection to the stopped
service is refused. That is the operating system, not the program.

## Simplifications, named

- **Three apps in one process and one project.** Real services are separate
  projects, built, deployed and scaled separately. Hosting them together keeps
  the lesson to one folder and one command; nothing in the code depends on it.
- **The gateway forwards with `HttpClient`.** A production gateway is usually
  a reverse proxy such as YARP, or a managed gateway, with timeouts, retries,
  authentication and rate limits. The forwarding here is the idea, not the
  product.
- **Ports are chosen by the operating system** (port 0) and read back, so there
  is no address to keep in step anywhere (§16.6). `L038.http` says the same.
- **Server log lines are switched off** so the console shows the lesson's
  output only.

## This week's drill

Take one call between two parts of your own system and write down what would
have to be true for it to cross a network: what happens when the other side is
slow, down, or answers twice.
