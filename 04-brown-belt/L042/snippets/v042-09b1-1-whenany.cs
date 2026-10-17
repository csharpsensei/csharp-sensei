using var stop = new CancellationTokenSource();

Task<Quote>[] asking = firms
    .Select(firm => firm.QuoteAsync(stop.Token))
    .ToArray();
Task<Quote> first = await Task.WhenAny(asking);
stop.Cancel();
