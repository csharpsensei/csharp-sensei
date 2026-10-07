command.CommandText = "SELECT Email, Name FROM Members WHERE Email = $email";

return new Member(reader.GetString(0), reader.GetString(1));
