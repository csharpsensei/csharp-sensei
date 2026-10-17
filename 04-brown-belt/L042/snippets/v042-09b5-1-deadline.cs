using var deadline =
    new CancellationTokenSource(TimeSpan.FromMilliseconds(150));

Task<Quote>[] asking = firms
    .Select(firm => firm.QuoteAsync(deadline.Token))
