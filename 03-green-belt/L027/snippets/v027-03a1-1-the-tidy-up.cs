public int PriceInPence(Parcel parcel)
{
    int price = parcel.Grams < 1000 ? 350
              : parcel.Grams < 2000 ? 550
              : 850;

    return parcel.Express ? price + 250 : price;
}
