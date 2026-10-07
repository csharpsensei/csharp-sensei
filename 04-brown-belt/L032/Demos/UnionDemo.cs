using WhatsNew.Payments;

namespace WhatsNew.Demos;

public static class UnionDemo
{
    public static void Run()
    {
        Console.WriteLine("Unions");
        decimal[] amounts = [42, 0, 750];
        foreach (decimal amount in amounts)
        {
            PaymentResult result = CardGateway.Charge(amount);
            Console.WriteLine($"  {amount,4}: {PaymentMessages.Explain(result)}");
        }
    }
}
