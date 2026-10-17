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
