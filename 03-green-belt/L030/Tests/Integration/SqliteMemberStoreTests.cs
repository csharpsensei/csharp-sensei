using IntegrationTests.App.Members;

namespace IntegrationTests.Tests.Integration;

/// <summary>
/// Integration tests: the store against a real SQLite database file. xUnit
/// builds a new instance of this class for every test, so every test gets a
/// database of its own, and Dispose deletes it afterwards.
/// </summary>
[Trait("Kind", "Integration")]
public sealed class SqliteMemberStoreTests : IDisposable
{
    private readonly string _path =
        Path.Combine(Path.GetTempPath(), $"l030-{Guid.NewGuid():N}.db");

    private readonly string _connectionString;

    public SqliteMemberStoreTests()
    {
        // Pooling off, so every connection really closes and the file can be
        // deleted when the test is over.
        _connectionString = $"Data Source={_path};Pooling=False";
        new SqliteMemberStore(_connectionString).CreateTable();
    }

    [Fact]
    public void FindByEmail_AfterTryAdd_ReturnsTheSameMember()
    {
        // Arrange
        Member added = new("Sam Lee", "sam@example.com");
        new SqliteMemberStore(_connectionString).TryAdd(added);
        SqliteMemberStore freshStore = new(_connectionString);

        // Act
        Member? found = freshStore.FindByEmail("sam@example.com");

        // Assert
        Assert.Equal(added, found);
    }

    [Fact]
    public void FindByEmail_UnknownEmail_ReturnsNull()
    {
        // Arrange
        SqliteMemberStore store = new(_connectionString);

        // Act
        Member? found = store.FindByEmail("nobody@example.com");

        // Assert
        Assert.Null(found);
    }

    [Fact]
    public void TryAdd_SameEmailTwice_ReturnsFalse()
    {
        // Arrange
        SqliteMemberStore store = new(_connectionString);
        store.TryAdd(new Member("Sam Lee", "sam@example.com"));

        // Act
        bool added = store.TryAdd(new Member("Sam Lowe", "sam@example.com"));

        // Assert
        Assert.False(added);
    }

    public void Dispose()
    {
        File.Delete(_path);
    }
}
