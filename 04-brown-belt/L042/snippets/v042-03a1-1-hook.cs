var quotes = new List<Quote>();
foreach (TaxiFirm firm in firms)
{
    quotes.Add(await firm.QuoteAsync(CancellationToken.None));
}
