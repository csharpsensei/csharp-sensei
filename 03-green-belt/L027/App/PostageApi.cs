using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WhyWeTest.App;

/// <summary>
/// The whole application: two endpoints over the calculator and the store.
/// In a real solution this wiring lives in the app's own Program.cs. Here the
/// end to end test hosts it, so the lesson stays in one project (see README).
/// </summary>
public static class PostageApi
{
    public static WebApplication Build(string url, string quoteFolder)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        // The server's own log lines would land in the middle of the test
        // runner's output, so the lesson's console stills turn them off.
        builder.Logging.ClearProviders();

        builder.Services.AddSingleton<PostageCalculator>();
        builder.Services.AddSingleton<IQuoteStore>(new JsonQuoteStore(quoteFolder));

        WebApplication app = builder.Build();
        app.Urls.Add(url);

        app.MapPost("/quotes", async (
            QuoteRequest request, PostageCalculator calculator, IQuoteStore store) =>
        {
            if (request.Grams <= 0 || request.Grams > PostageCalculator.MaxGrams)
            {
                return Results.BadRequest("A parcel weighs 1 to 5000 grams.");
            }

            int price = calculator.PriceInPence(new Parcel(request.Grams, request.Express));
            Quote quote = new(Guid.NewGuid(), request.Grams, request.Express, price);
            await store.SaveAsync(quote);
            return Results.Created($"/quotes/{quote.Id}", quote);
        });

        app.MapGet("/quotes/{id:guid}", async (Guid id, IQuoteStore store) =>
            await store.LoadAsync(id) is Quote quote
                ? Results.Ok(quote)
                : Results.NotFound());

        return app;
    }
}
