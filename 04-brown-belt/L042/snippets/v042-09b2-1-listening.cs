public async Task<Quote> QuoteAsync(CancellationToken cancel)
{
    if (!open)
        throw new FirmClosedException(name);

    await Task.Delay(answersIn, cancel);
    return new Quote(name, (int)answersIn.TotalMilliseconds / 20);
}
