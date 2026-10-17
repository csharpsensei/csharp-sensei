var outside = new List<string>();
IDeliveryQuote logFirst =
    new LoggingQuote(new CachingQuote(new CourierQuote()), outside);

var inside = new List<string>();
IDeliveryQuote cacheFirst =
    new CachingQuote(new LoggingQuote(new CourierQuote(), inside));
