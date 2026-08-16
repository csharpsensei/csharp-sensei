public decimal PriceFor(Parcel parcel, string carrier)
{
    switch (carrier)
    {
        case "Standard":
            return parcel.WeightKg * 2.50m;

        case "Express":
            return parcel.WeightKg * 4.00m + 3.00m;

        case "Overnight":
            ...
    }
}
