using System.Diagnostics;
using CoordinatingTasks.Reporting;
using CoordinatingTasks.Taxis;

// Composition root only. Times are rounded DOWN to the nearest 100 ms,
// because a delay can only ever take longer than asked, never shorter.

await Pass1OneAfterAnother();
await Pass2AllAtOnce();
await Pass3FirstToAnswer();
await Pass4Deadline();
await Pass5TwoFailures();

static async Task Pass1OneAfterAnother()
{
    TaxiFirm[] firms = Firms.ThreeOpen();
    var clock = Stopwatch.StartNew();

    var quotes = new List<Quote>();
    foreach (TaxiFirm firm in firms)
    {
        quotes.Add(await firm.QuoteAsync(CancellationToken.None));
    }

    Log.Pass("Pass 1: three quotes, awaited one after another");
    Log.Item("quotes back      " + quotes.Count);
    Log.Item("time taken       " + Describe.Millis(clock) + " ms");
}

static async Task Pass2AllAtOnce()
{
    TaxiFirm[] firms = Firms.ThreeOpen();
    var clock = Stopwatch.StartNew();

    Task<Quote>[] asking = firms
        .Select(firm => firm.QuoteAsync(CancellationToken.None))
        .ToArray();
    Quote[] quotes = await Task.WhenAll(asking);

    Log.Pass("Pass 2: the same three, started together, WhenAll");
    Log.Item("quotes back      " + quotes.Length);
    Log.Item("time taken       " + Describe.Millis(clock) + " ms");
}

static async Task Pass3FirstToAnswer()
{
    TaxiFirm[] firms = Firms.ThreeOpen();
    using var stop = new CancellationTokenSource();

    Task<Quote>[] asking = firms
        .Select(firm => firm.QuoteAsync(stop.Token))
        .ToArray();
    Task<Quote> first = await Task.WhenAny(asking);
    stop.Cancel();

    Log.Pass("Pass 3: book the first to answer, cancel the rest");
    Log.Item("booked           " + (await first).Firm);
    for (int i = 0; i < asking.Length; i++)
    {
        if (asking[i] == first) continue;
        Log.Item(firms[i].Name.PadRight(17) + await Describe.Outcome(asking[i]));
    }
}

static async Task Pass4Deadline()
{
    TaxiFirm[] firms = Firms.ThreeOpen();
    using var deadline =
        new CancellationTokenSource(TimeSpan.FromMilliseconds(150));

    Task<Quote>[] asking = firms
        .Select(firm => firm.QuoteAsync(deadline.Token))
        .ToArray();

    string result;
    try
    {
        await Task.WhenAll(asking);
        result = "all three answered";
    }
    catch (OperationCanceledException)
    {
        result = "deadline passed";
    }

    Log.Pass("Pass 4: all three, with a 150 ms deadline");
    Log.Item("result           " + result);
    Log.Item("answered         "
        + asking.Count(t => t.IsCompletedSuccessfully) + " of 3");
}

static async Task Pass5TwoFailures()
{
    TaxiFirm[] firms = Firms.TwoClosed();
    Task<Quote>[] asking = firms
        .Select(firm => firm.QuoteAsync(CancellationToken.None))
        .ToArray();
    Task<Quote[]> all = Task.WhenAll(asking);

    string rethrown;
    try
    {
        await all;
        rethrown = "nothing";
    }
    catch (FirmClosedException ex)
    {
        rethrown = ex.Message;
    }

    Log.Pass("Pass 5: two firms closed, WhenAll awaited");
    Log.Item("await rethrew    " + rethrown);
    Log.Item("the task held    "
        + all.Exception!.InnerExceptions.Count + " exceptions");
}
