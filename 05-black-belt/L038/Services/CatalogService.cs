using Microservices.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Microservices.Services;

/// <summary>The catalog service: owns product names, and nothing else.</summary>
public static class CatalogService
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/products/{id:int}",
            (int id) => Results.Ok(new Product(id, "Hiking boots")));
    }
}
