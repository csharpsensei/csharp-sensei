namespace DesignPatterns.Creating;

/// <summary>
/// Creational family, light touch. The one place that knows which concrete
/// service a feed code means. Adding a third kind edits this file and no other.
/// </summary>
public static class ServiceFactory
{
    public static IService For(string code) => code switch
    {
        "TRN" => new TrainService(),
        "BUS" => new BusService(),
        _ => throw new ArgumentException(
                 $"Unknown service code '{code}'.", nameof(code))
    };
}
