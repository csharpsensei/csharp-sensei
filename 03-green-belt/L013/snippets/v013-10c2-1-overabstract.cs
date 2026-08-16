public interface IShippingRateFactory { ... }
public interface IShippingRateFactoryProvider { ... }

public class StandardRateFactory : IShippingRateFactory { ... }
public class ExpressRateFactory : IShippingRateFactory { ... }

public class ConfiguredRateFactoryProvider
    : IShippingRateFactoryProvider
{
    private static readonly string[] EnabledCarriers =
        { "Standard", "Express" };
    ...
}
