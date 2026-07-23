var services = new ServiceCollection();

services.AddSingleton<ISingletonStamp, SingletonStamp>();
services.AddScoped<IScopedStamp, ScopedStamp>();
services.AddTransient<ITransientStamp, TransientStamp>();

var provider = services.BuildServiceProvider(new ServiceProviderOptions
{
    ValidateOnBuild = true,
    ValidateScopes = true
});
