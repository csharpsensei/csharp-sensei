namespace IntegrationTests.App.Members;

/// <summary>
/// The edge where members are kept. In the real system this is a SQLite
/// database file.
/// </summary>
public interface IMemberStore
{
    bool TryAdd(Member member);

    Member? FindByEmail(string email);
}
