var journal = new List<string>();
var flaky = new FlakyCourierQuote();
IDeliveryQuote quote =
    new LoggingQuote(
        new CachingQuote(
            new RetryingQuote(flaky, maxAttempts: 3)),
        journal);
