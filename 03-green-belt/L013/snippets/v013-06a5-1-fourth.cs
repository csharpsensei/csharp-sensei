        case "Overnight":
            ...

        // added today, inside a method
        // three working carriers share
        case "International":
            return parcel.WeightKg * 9.00m + 15.00m;

        default: throw new ArgumentException(...);
