    public IEnumerable<string> Rows()
    {
        foreach (Departure departure in _source.Next())
        {
            string note = _policy.Announce(departure);
            string label = departure.Service.Label;

            yield return (departure.Due.ToString("HH:mm") + "  "
                          + departure.Destination.PadRight(12)
                          + label.PadRight(16) + note).TrimEnd();
        }
    }
