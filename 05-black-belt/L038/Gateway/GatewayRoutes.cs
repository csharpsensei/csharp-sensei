namespace Microservices.Gateway;

/// <summary>Where each service really lives. The gateway is the only thing that needs to know.</summary>
public sealed record GatewayRoutes(Uri Catalog, Uri Stock);
