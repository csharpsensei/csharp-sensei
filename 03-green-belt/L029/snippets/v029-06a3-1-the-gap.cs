int full = _pricer.PriceInPence(request.Seats);
int percentOff = _discount.PercentOff(request.Student);
int total = full - percentOff;
