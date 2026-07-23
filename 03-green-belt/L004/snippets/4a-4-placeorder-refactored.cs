    public void PlaceOrder(Order order)
    {
        var result = _payments.Charge(order.CustomerId, order.Total);

        if (!result.Succeeded)
        {
            throw new PaymentFailedException(result.Reason);
        }

        _repository.Save(order);
        _email.Send(order.CustomerEmail, "Order confirmed",
            $"Thanks for order {order.Id}.");
    }
