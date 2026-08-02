using (logger.BeginScope(new Dictionary<string, object>
       {
           ["user.id"]   = request.UserId,
           ["user.tier"] = request.Tier
       }))
{
    logger.LogInformation("checkout started");
}
