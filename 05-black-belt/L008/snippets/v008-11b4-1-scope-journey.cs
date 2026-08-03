// AT THE DOOR — immutable, set once, carried by everything below
using var who = logger.BeginScope(new Dictionary<string, object>
{
    ["user.id"] = request.UserId, ["user.tier"] = request.Tier
});
logger.LogInformation("checkout started");

// THE JOURNEY WIDENS — nesting ADDS, it does not replace
using var cart = logger.BeginScope(cartFields);
logger.LogInformation("cart priced");

// WIDER STILL — the whole journey, on one line
using var payment = logger.BeginScope(paymentFields);
logger.LogInformation("payment settled");
