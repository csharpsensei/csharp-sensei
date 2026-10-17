using Microservices.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Microservices.Services;

/// <summary>The stock service: owns how many are left, and nothing else.</summary>
public static class StockService
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/levels/{id:int}",
            (int id) => Results.Ok(new StockLevel(id, 4)));
    }
}
