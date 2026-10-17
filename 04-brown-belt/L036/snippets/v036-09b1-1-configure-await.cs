public static async Task<string> FetchWithoutContextAsync()
{
    await Task.Delay(100).ConfigureAwait(false);
    return "hello from the library";
}
