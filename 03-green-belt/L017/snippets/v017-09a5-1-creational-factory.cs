public interface IService
{
    string Label { get; }
}

public static class ServiceFactory
{
    public static IService For(string code) => code switch
    {
        "TRN" => new TrainService(),
        "BUS" => new BusService(),
        _ => throw new ArgumentException(
                 $"Unknown service code '{code}'.", nameof(code))
    };
