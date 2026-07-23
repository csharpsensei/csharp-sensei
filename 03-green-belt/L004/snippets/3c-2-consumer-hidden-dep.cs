public sealed class InvoiceService
{
    public void Issue(Order order)
    {
        var repository = ServiceLocator.Resolve<IOrderRepository>();
        var email = ServiceLocator.Resolve<IEmailSender>();
        var pdf = ServiceLocator.Resolve<IPdfRenderer>();

        var invoice = pdf.Render(order);
        repository.SaveInvoice(invoice);
        email.Send(order.CustomerEmail, "Your invoice", invoice.Url);
    }
}
