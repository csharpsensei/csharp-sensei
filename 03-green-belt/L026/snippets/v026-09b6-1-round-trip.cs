    public static T RoundTrip<T>(T value)
    {
        string json = JsonSerializer.Serialize(value);
        T? copy = JsonSerializer.Deserialize<T>(json);

        if (copy is null)
        {
            throw new InvalidOperationException("nothing came back");
        }

        return copy;
    }
