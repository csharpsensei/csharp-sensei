namespace AsyncDeadlock.Library;

/// <summary>
/// Stands in for library code: something slow, awaited. The delay is the
/// "slow", and the only thing that matters is where the code resumes after it.
/// </summary>
public static class GreetingService
{
    public static async Task<string> FetchAsync()
    {
        await Task.Delay(100);
        return "hello from the library";
    }

    public static async Task<string> FetchWithoutContextAsync()
    {
        await Task.Delay(100).ConfigureAwait(false);
        return "hello from the library";
    }
}
