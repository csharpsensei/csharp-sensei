using IntegrationTests.App.Members;
using Microsoft.Data.Sqlite;

namespace IntegrationTests.Regression;

/// <summary>
/// DO NOT COPY THIS SHAPE. The member store with one line wrong: the SELECT
/// asks for Email then Name, and the mapping still reads Name then Email. Both
/// columns are text, so it compiles, it runs, and it hands back a member with
/// the name and the email swapped. Every unit and component test still passes,
/// because none of them runs this SQL.
/// </summary>
public sealed class BrokenSqliteMemberStore : IMemberStore
{
    private readonly string _connectionString;

    public BrokenSqliteMemberStore(string connectionString)
    {
        _connectionString = connectionString;
    }

    public bool TryAdd(Member member)
    {
        using SqliteConnection connection = Open();
        using SqliteCommand command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Members (Email, Name) VALUES ($email, $name)";
        command.Parameters.AddWithValue("$email", member.Email);
        command.Parameters.AddWithValue("$name", member.Name);
        command.ExecuteNonQuery();
        return true;
    }

    public Member? FindByEmail(string email)
    {
        using SqliteConnection connection = Open();
        using SqliteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT Email, Name FROM Members WHERE Email = $email";
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
