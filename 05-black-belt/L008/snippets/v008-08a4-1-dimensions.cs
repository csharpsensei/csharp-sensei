logger.LogInformation(
    "Payment attempted {UserId} {Tier} {CartValue} " +
    "{Gateway} {DeclineCode} {Attempt}",
    userId, tier, cartValue,
    gateway, declineCode, attempt);
