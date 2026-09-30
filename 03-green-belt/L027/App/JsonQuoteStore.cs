using System.Text.Json;

namespace WhyWeTest.App;

/// <summary>
/// Keeps each quote as one JSON file in a folder. This is the part of the
/// application that talks to something outside it, the disk and the
/// serialiser, which is exactly what an integration test is for.
/// </summary>
public sealed class JsonQuoteStore : IQuoteStore
{
    private readonly string _folder;

    public JsonQuoteStore(string folder)
    {
        _folder = folder;
        Directory.CreateDirectory(folder);
    }

    public async Task SaveAsync(Quote quote)
    {
        await using FileStream file = File.Create(PathFor(quote.Id));
        await JsonSerializer.SerializeAsync(file, quote);
    }

    public async Task<Quote?> LoadAsync(Guid id)
    {
        string path = PathFor(id);
        if (!File.Exists(path))
        {
            return null;
        }

        await using FileStream file = File.OpenRead(path);
        return await JsonSerializer.DeserializeAsync<Quote>(file);
    }

    private string PathFor(Guid id) => Path.Combine(_folder, $"{id}.json");
}
