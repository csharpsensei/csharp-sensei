using DecoratorPattern.Decorators;
using DecoratorPattern.Quotes;
using DecoratorPattern.Reporting;

// Composition root only. Every decorator is wired by hand here, which is
// the whole of what a container would do for you.

Pass1Plain();
Pass2Cached();
Pass3OrderMatters();
Pass4Retry();
Pass5Stacked();

static void Pass1Plain()
{
    var courier = new CourierQuote();
    IDeliveryQuote quote = courier;

    int days = 0;
    for (int i = 0; i < 3; i++) days = quote.DaysTo("LS1");

    Log.Pass("Pass 1: three lookups, straight to the courier");
    Log.Item("days to LS1      " + days);
    Log.Item("courier calls    " + courier.Calls);
}

static void Pass2Cached()
{
    var courier = new CourierQuote();
    IDeliveryQuote quote = new CachingQuote(courier);

    int days = 0;
    for (int i = 0; i < 3; i++) days = quote.DaysTo("LS1");

    Log.Pass("Pass 2: the same three, through a caching wrapper");
    Log.Item("days to LS1      " + days);
    Log.Item("courier calls    " + courier.Calls);
}

static void Pass3OrderMatters()
{
    var outside = new List<string>();
    IDeliveryQuote logFirst =
        new LoggingQuote(new CachingQuote(new CourierQuote()), outside);

    var inside = new List<string>();
    IDeliveryQuote cacheFirst =
        new CachingQuote(new LoggingQuote(new CourierQuote(), inside));

    for (int i = 0; i < 3; i++)
    {
        logFirst.DaysTo("EH3");
        cacheFirst.DaysTo("EH3");
    }

    Log.Pass("Pass 3: the same two wrappers, two orders");
    Log.Item("logging outside  " + outside.Count + " lines logged");
    Log.Item("logging inside   " + inside.Count + " line logged");
}

static void Pass4Retry()
{
    var flaky = new FlakyCourierQuote();
    IDeliveryQuote quote = new RetryingQuote(flaky, maxAttempts: 3);

    int days = quote.DaysTo("CF10");

    Log.Pass("Pass 4: a courier that fails once, behind a retry wrapper");
    Log.Item("days to CF10     " + days);
    Log.Item("attempts made    " + flaky.Attempts);
}

static void Pass5Stacked()
{
    var journal = new List<string>();
    var flaky = new FlakyCourierQuote();
    IDeliveryQuote quote =
        new LoggingQuote(
            new CachingQuote(
                new RetryingQuote(flaky, maxAttempts: 3)),
            journal);

    for (int i = 0; i < 3; i++) quote.DaysTo("CF10");

    Log.Pass("Pass 5: all three wrappers, one courier");
    Log.Item("lookups asked    3");
    Log.Item("lines logged     " + journal.Count);
    Log.Item("courier attempts " + flaky.Attempts);
}
