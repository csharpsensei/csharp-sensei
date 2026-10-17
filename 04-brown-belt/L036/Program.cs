using AsyncDeadlock.Legacy;
using AsyncDeadlock.Library;
using AsyncDeadlock.Reporting;
using AsyncDeadlock.Threading;

// Composition root only. Every wait on the context thread has a timeout,
// so a deadlock is reported rather than hanging the console.

TimeSpan patience = TimeSpan.FromSeconds(2);

Pass1ResultInsideTheContext(patience);
Pass2ResultWithNoContext();
Pass3AwaitAllTheWay(patience);
Pass4LibraryOptsOut(patience);
Pass5HandlerOptsOut(patience);

static void Pass1ResultInsideTheContext(TimeSpan patience)
{
    var context = new SingleThreadContext();

    string? answer = context.Run(
        () => Task.FromResult(BlockingCaller.GetGreeting()), patience);

    Log.Pass("Pass 1: .Result inside the one-thread context");
    Log.Item(answer ?? "no answer after 2 s: deadlocked");
}

static void Pass2ResultWithNoContext()
{
    string answer = BlockingCaller.GetGreeting();

    Log.Pass("Pass 2: the same .Result, on a plain console thread");
    Log.Item(answer);
}

static void Pass3AwaitAllTheWay(TimeSpan patience)
{
    var context = new SingleThreadContext();

    string? answer = context.Run(async () =>
    {
        string greeting = await GreetingService.FetchAsync();
        return greeting + "  |  resumed on the context thread: "
            + Describe.YesNo(context.IsCurrentThread);
    }, patience);

    Log.Pass("Pass 3: await all the way, inside the context");
    Log.Item(answer ?? "no answer after 2 s: deadlocked");
}

static void Pass4LibraryOptsOut(TimeSpan patience)
{
    var context = new SingleThreadContext();

    string? answer = context.Run(
        () => Task.FromResult(BlockingCaller.GetGreetingFromSafeLibrary()),
        patience);

    Log.Pass("Pass 4: .Result over a library that skips the context");
    Log.Item(answer ?? "no answer after 2 s: deadlocked");
}

static void Pass5HandlerOptsOut(TimeSpan patience)
{
    var context = new SingleThreadContext();

    string? answer = context.Run(async () =>
    {
        await GreetingService.FetchAsync().ConfigureAwait(false);
        return "resumed on the context thread: "
            + Describe.YesNo(context.IsCurrentThread);
    }, patience);

    Log.Pass("Pass 5: the handler itself skips the context");
    Log.Item(answer ?? "no answer after 2 s: deadlocked");
}
