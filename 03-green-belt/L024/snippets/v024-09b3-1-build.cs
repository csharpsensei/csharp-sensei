    public Booking Build()
    {
        List<string> problems = Problems();

        if (problems.Count > 0)
        {
            throw new InvalidOperationException(string.Join("; ", problems));
        }

        return new Booking(_guestName, _checkIn!.Value, _checkOut!.Value, _adults, _children,
                           _room!.Value, _breakfast, _cot, _requests.ToArray());
    }
