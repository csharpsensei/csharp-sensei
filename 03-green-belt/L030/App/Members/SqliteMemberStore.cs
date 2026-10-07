using Microsoft.Data.Sqlite;

namespace IntegrationTests.App.Members;

/// <summary>
/// Keeps members in a real SQLite database. This is the part of the
/// application that talks to something outside it, so it is the part an
/// integration test is for. Every call is synchronous on purpose: Microsoft's
/// own guidance is that SQLite has no asynchronous I/O, so the async methods
/// run synchronously in Microsoft.Data.Sqlite and should be avoided.
/// </summary>
public sealed class SqliteMemberStore : IMemberStore
{
    // SQLITE_CONSTRAINT, from sqlite.org's result code list. A primary key
    // clash is one kind of constraint failure.
    private const int SqliteConstraint = 19;

    private readonly string _connectionString;

    public SqliteMemberStore(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void CreateTable()
    {
        using SqliteConnection connection = Open();
        using SqliteCommand command = connection.CreateCommand();
        command.CommandText =
            "CREATE TABLE IF NOT EXISTS Members (Email TEXT PRIMARY KEY, Name TEXT NOT NULL)";
        command.ExecuteNonQuery();
    }

    public bool TryAdd(Member member)
    {
        using SqliteConnection connection = Open();
        using SqliteCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Members (Email, Name) VALUES ($email, $name)";
        command.Parameters.AddWithValue("$email", member.Email);
        command.Parameters.AddWithValue("$name", member.Name);

        try
        {
            command.ExecuteNonQuery();
            return true;
        }
        catch (SqliteException ex) when (ex.SqliteErrorCode == SqliteConstraint)
        {
            return false;
        }
    }

    public Member? FindByEmail(string email)
    {
        using SqliteConnection connection = Open();
        using SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT Name, Email FROM Members WHERE Email = $email";
        command.Parameters.AddWithValue("$email", email);

        using SqliteDataReader reader = command.ExecuteReader();
        if (!reader.Read())
        {
            return null;
        }

        return new Member(reader.GetString(0), reader.GetString(1));
    }

    private SqliteConnection Open()
    {
        SqliteConnection connection = new(_connectionString);
        connection.Open();
        return connection;
    }
}
