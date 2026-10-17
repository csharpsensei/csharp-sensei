namespace Microservices.Monolith;

/// <summary>The catalog, as a class inside one app.</summary>
public sealed class CatalogModule
{
    public string NameOf(int productId) => "Hiking boots";
}
