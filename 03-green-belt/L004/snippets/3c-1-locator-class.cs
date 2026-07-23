public static class ServiceLocator
{
    private static IServiceProvider _provider = default!;

    public static void Initialise(IServiceProvider provider)
        => _provider = provider;

    public static T Resolve<T>() where T : notnull
        => _provider.GetRequiredService<T>();
}
