    public void Issue(Order order)
    {
        var invoice = _pdf.Render(order);

        _repository.SaveInvoice(invoice);
        _email.Send(order.CustomerEmail, "Your invoice", invoice.Url);
    }
