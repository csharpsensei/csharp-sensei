using (logger.BeginScope(outer))     // user.id, user.tier
{
    logger.LogInformation("checkout started");

    using (logger.BeginScope(inner)) // + cart.value, cart.items
    {
        logger.LogInformation("cart priced");
    }                                // inner fields gone from here

    logger.LogInformation("checkout finished");
}
