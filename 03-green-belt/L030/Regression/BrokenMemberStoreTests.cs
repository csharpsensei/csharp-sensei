using IntegrationTests.App.Members;

namespace IntegrationTests.Regression;

/// <summary>
/// The first integration test, pointed at the broken store. Explicit, so a
/// plain `dotnet run` skips it and stays green.
/// </summary>
public sealed class BrokenMemberStoreTests : IDisposable
{
    private readonly string _path =
        Path.Combine(Path.GetTempPath(), $"l030-{Guid.NewGuid():N}.db");

    private readonly string _connectionString;

    public BrokenMemberStoreTests()
    {
        _connectionString = $"Data Source={_path};Pooling=False";
        new SqliteMemberStore(_connectionString).CreateTable();
    }

    [Fact(Explicit = true)]
    public void FindByEmail_AfterTryAdd_ReturnsTheSameMember()
    {
        // Arrange
        Member added = new("Sam Lee", "sam@example.com");
        new BrokenSqliteMemberStore(_connectionString).TryAdd(added);
        BrokenSqliteMemberStore freshStore = new(_connectionString);

        // Act
        Member? found = freshStore.FindByEmail("sam@example.com");

        // Assert
        Assert.Equal(added, found);
    }

    public void Dispose()
    {
        File.Delete(_path);
    }
}
