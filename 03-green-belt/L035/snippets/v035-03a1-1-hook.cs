public int DaysTo(string postcode)
{
    Journal.Add("quote asked for " + postcode);
    if (_known.TryGetValue(postcode, out int days))
        return days;

    days = postcode.StartsWith("LS") ? 2 : 3;
    _known[postcode] = days;
    return days;
}
