public static PaymentResult Charge(decimal amount)
{
    if (amount <= 0)
    {
        return new Declined("amount must be above zero");
    }

    if (amount > 500)
    {
        return new Challenged("bank app");
    }

    return new Approved("A1B2");
}
