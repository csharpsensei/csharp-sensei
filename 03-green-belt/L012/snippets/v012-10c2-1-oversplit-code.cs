public class TotalCalculator
{
    private readonly LineItemSummer _summer = new();
    private readonly TaxCalculator _tax = new();
    private readonly DiscountCalculator _discount = new();

    public decimal Calculate(Invoice invoice) { ... }
}
