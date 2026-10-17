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
