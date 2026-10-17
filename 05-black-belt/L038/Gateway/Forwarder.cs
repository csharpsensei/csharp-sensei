using Microsoft.AspNetCore.Http;

namespace Microservices.Gateway;

/// <summary>
/// Passes a GET on to one service and hands back what it said. If the
/// service cannot be reached, the caller gets a 503 that names it, rather
/// than an exception from deep inside the gateway.
/// </summary>
public static class Forwarder
{
    public static async Task<IResult> GetAsync(
        IHttpClientFactory http, Uri service, string path, string name)
    {
        HttpClient client = http.CreateClient();
        try
        {
            using HttpResponseMessage response =
                await client.GetAsync(new Uri(service, path));
            string body = await response.Content.ReadAsStringAsync();
            return Results.Content(body, "application/json",
                statusCode: (int)response.StatusCode);
        }
        catch (HttpRequestException)
        {
            return Results.Problem(
                title: name + " service unavailable", statusCode: 503);
        }
    }
}
