public decimal PriceFor(Parcel parcel, string carrier)
{
    switch (carrier)
    {
        case "Standard":  ...
        case "Express":   ...
        case "Overnight": ...

        default: throw new ArgumentException(...);
    }
}
