namespace CoordinatingTasks.Taxis;

/// <summary>
/// Stands in for a call to a taxi firm's booking service. The answer time is
/// a fixed delay, so the passes have something real to wait for; the
/// cancellation token is passed to the delay, so a cancelled request stops
/// waiting at once. A simplification named in the README.
/// </summary>
public sealed class TaxiFirm(string name, TimeSpan answersIn, bool open = true)
{
    public string Name => name;

    public async Task<Quote> QuoteAsync(CancellationToken cancel)
    {
        if (!open)
            throw new FirmClosedException(name);

        await Task.Delay(answersIn, cancel);
        return new Quote(name, (int)answersIn.TotalMilliseconds / 20);
    }
}
