public ShippingService(
    IOrderRepository orders,
    ICustomerRepository customers,
    IEmailSender email,
    ISmsSender sms,
    IPushNotifier push,
    IAddressValidator addresses,
    ICarrierClient carriers,
    ILabelPrinter labels,
    IAuditLog audit,
    IClock clock)
{
}
