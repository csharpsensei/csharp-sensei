public sealed class SqliteMemberStoreTests : IDisposable
{
    private readonly string _path =
        Path.Combine(Path.GetTempPath(), $"l030-{Guid.NewGuid():N}.db");

    public SqliteMemberStoreTests()
    {
        _connectionString = $"Data Source={_path};Pooling=False";
        new SqliteMemberStore(_connectionString).CreateTable();
    }

    public void Dispose()
    {
        File.Delete(_path);
    }
}
