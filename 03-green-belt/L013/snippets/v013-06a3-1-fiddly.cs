case "Overnight":
    decimal flatFee = 12.00m;

    if (parcel.WeightKg <= 2.00m)
    {
        return flatFee;
    }

    return flatFee + (parcel.WeightKg - 2.00m) * 6.50m;
