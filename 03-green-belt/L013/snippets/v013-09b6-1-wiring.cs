IShippingRate[] rates =
{
    new StandardRate(),
    new ExpressRate(),
    new OvernightRate(),
};

ShippingCalculator calculator = new ShippingCalculator(rates);
