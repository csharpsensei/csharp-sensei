namespace Microservices.Reporting;

/// <summary>Calls one gateway path and reports the path and the status code.</summary>
public static class Probe
{
    public static async Task<string> StatusOf(HttpClient client, Uri gateway, string path)
    {
        using HttpResponseMessage response =
            await client.GetAsync(new Uri(gateway, path));
        return ("/" + path).PadRight(22) + (int)response.StatusCode;
    }
}
