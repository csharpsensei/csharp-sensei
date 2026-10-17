using AsyncDeadlock.Library;

namespace AsyncDeadlock.Legacy;

/// <summary>
/// DO NOT COPY THIS SHAPE. Synchronous code blocking on asynchronous code
/// with .Result. It works on a plain console thread and deadlocks on a
/// one-thread context. Kept so the lesson can run both.
/// </summary>
public static class BlockingCaller
{
    public static string GetGreeting()
    {
        return GreetingService.FetchAsync().Result;
    }

    public static string GetGreetingFromSafeLibrary()
    {
        return GreetingService.FetchWithoutContextAsync().Result;
    }
}
