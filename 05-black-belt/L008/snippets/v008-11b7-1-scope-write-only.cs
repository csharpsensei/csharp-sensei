// Inside SimulatedPaymentGateway, four frames down:

logger.CurrentScope.Set("payment.gateway", gateway);  // does not exist

using (logger.BeginScope(paymentFields))
{
    logger.LogInformation("payment settled");
}   // ...and payment.gateway is gone again
