builder.Services
    .AddOpenTelemetry()
    .UseAzureMonitor();

// No connection string here, and none in the repo.
// Azure Monitor reads it from user-secrets or the environment.
