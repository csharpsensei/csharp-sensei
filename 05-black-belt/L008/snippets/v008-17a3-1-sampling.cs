builder.Services.AddOpenTelemetry().UseAzureMonitor(o =>
{
    o.TracesPerSecond = null;   // off: it OVERRIDES the ratio below
    o.SamplingRatio = 1.0F;     // keep everything while you learn
});
