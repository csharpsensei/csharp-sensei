using System.Globalization;
using OpenClosed.Legacy;
using OpenClosed.OverAbstracted;
using OpenClosed.Shipping;

// Composition root. Four passes, matching the lesson's three cycles plus the
// payoff that closes cycle b.
//
// The lesson prints money, so the culture is pinned here rather than left to
// the machine's regional settings. Without this line the same code prints
// different symbols on different computers, and the console stills in the
// package would only be right on one of them.
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-GB");

Parcel parcel = new Parcel(3.4m, "Manchester");

// ---------------------------------------------------------------------------
// Pass 1: the violation. One method, one switch, every carrier inside it.
// ---------------------------------------------------------------------------
Console.WriteLine("Pass 1: the switch");

ShippingCalculatorSwitch legacy = new ShippingCalculatorSwitch();

foreach (string carrier in new[] { "Standard", "Express", "Overnight" })
{
    Console.WriteLine($"  {carrier,-14}{legacy.PriceFor(parcel, carrier),9:C}");
}

Console.WriteLine();

// ---------------------------------------------------------------------------
// Pass 2: the refactor. Same prices, one class per rule, no switch anywhere.
// ---------------------------------------------------------------------------
Console.WriteLine("Pass 2: one rate per carrier");

IShippingRate[] rates =
{
    new StandardRate(),
    new ExpressRate(),
    new OvernightRate(),
};

ShippingCalculator calculator = new ShippingCalculator(rates);

foreach (IShippingRate rate in rates)
{
    Console.WriteLine($"  {rate.Carrier,-14}{calculator.PriceFor(parcel, rate.Carrier),9:C}");
}

Console.WriteLine();

// ---------------------------------------------------------------------------
// Pass 3: the payoff. International is a new file. Nothing above was opened
// to add it, and this list is the only line in the application that changed.
// ---------------------------------------------------------------------------
Console.WriteLine("Pass 3: adding International");

IShippingRate[] withInternational =
{
    new StandardRate(),
    new ExpressRate(),
    new OvernightRate(),
    new InternationalRate(),
};

ShippingCalculator extended = new ShippingCalculator(withInternational);

foreach (IShippingRate rate in withInternational)
{
    Console.WriteLine($"  {rate.Carrier,-14}{extended.PriceFor(parcel, rate.Carrier),9:C}");
}

Console.WriteLine();

// ---------------------------------------------------------------------------
// Pass 4: the boundary. DO NOT COPY. Every seam in OverAbstracted/ is open
// for extension, and the whole thing is harder to read than either version
// above. Same two prices, four extra types, one configuration lookup.
// ---------------------------------------------------------------------------
Console.WriteLine("Pass 4: the over-abstracted version (do not copy)");

ConfiguredRateFactoryProvider provider = new ConfiguredRateFactoryProvider();

IShippingRate[] built = provider.Factories()
    .Select(factory => factory.Create())
    .ToArray();

ShippingCalculator overAbstracted = new ShippingCalculator(built);

foreach (IShippingRate rate in built)
{
    Console.WriteLine($"  {rate.Carrier,-14}{overAbstracted.PriceFor(parcel, rate.Carrier),9:C}");
}
