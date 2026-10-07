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
