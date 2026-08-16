using OpenClosed.Shipping;

namespace OpenClosed.OverAbstracted;

// DO NOT COPY. This is cycle c: the same feature with a seam at every joint.
//
// It compiles, it runs, and every interface in it is genuinely open for
// extension, so by the letter of the principle it passes. It is still worse
// than both the switch and the refactor, for two reasons the lesson states
// out loud:
//
//   1. Answering "what does Express charge" now costs four files.
//   2. The set of carriers is looked up by NAME, so a typo is no longer a
//      compile error. It is a crash at start up. The switch this replaced
//      could at least be read from top to bottom.
//
// Grouped into one file on purpose. Spread across four, the point of the
// example would be even harder to see, which is itself the point.

/// <summary>A seam in front of "construct a rate", which has never varied.</summary>
public interface IShippingRateFactory
{
    string Carrier { get; }

    IShippingRate Create();
}

/// <summary>A seam in front of "know which factories exist".</summary>
public interface IShippingRateFactoryProvider
{
    IEnumerable<IShippingRateFactory> Factories();
}

public class StandardRateFactory : IShippingRateFactory
{
    public string Carrier => "Standard";

    public IShippingRate Create() => new StandardRate();
}

public class ExpressRateFactory : IShippingRateFactory
{
    public string Carrier => "Express";

    public IShippingRate Create() => new ExpressRate();
}

public class ConfiguredRateFactoryProvider : IShippingRateFactoryProvider
{
    // Stands in for the configuration file a real version of this would read.
    // It is inlined so the demo ships nothing extra, but the failure mode is
    // identical: these are strings, matched at run time, and nothing checks
    // them until the application starts.
    private static readonly string[] EnabledCarriers = { "Standard", "Express" };

    private readonly IShippingRateFactory[] _known =
    {
        new StandardRateFactory(),
        new ExpressRateFactory(),
    };

    public IEnumerable<IShippingRateFactory> Factories()
    {
        foreach (string name in EnabledCarriers)
        {
            IShippingRateFactory? factory =
                Array.Find(_known, f => f.Carrier == name);

            if (factory is null)
            {
                throw new InvalidOperationException(
                    $"Configuration names carrier '{name}', but no factory " +
                    "provides it. This is the typo that used to be a " +
                    "compile error.");
            }

            yield return factory;
        }
    }
}
