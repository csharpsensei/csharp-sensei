static void Report(IServiceProvider sp, string label)
{
    var singleton = sp.GetRequiredService<ISingletonStamp>();
    var scoped = sp.GetRequiredService<IScopedStamp>();
    var first = sp.GetRequiredService<ITransientStamp>();
    var second = sp.GetRequiredService<ITransientStamp>();

    Console.WriteLine($"{label}  singleton={singleton.Id}  scoped={scoped.Id}  " +
                      $"transient={first.Id},{second.Id}");
}

using (var scope = provider.CreateScope())
{
    Report(scope.ServiceProvider, "scope 1");
    Report(scope.ServiceProvider, "scope 1");
}

using (var scope = provider.CreateScope())
{
    Report(scope.ServiceProvider, "scope 2");
    Report(scope.ServiceProvider, "scope 2");
}
