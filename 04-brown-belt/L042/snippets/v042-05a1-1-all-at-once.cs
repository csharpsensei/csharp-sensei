Task<Quote>[] asking = firms
    .Select(firm => firm.QuoteAsync(CancellationToken.None))
    .ToArray();
Quote[] quotes = await Task.WhenAll(asking);
