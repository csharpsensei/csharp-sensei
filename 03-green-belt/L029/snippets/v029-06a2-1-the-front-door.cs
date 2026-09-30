public BookingResult Book(BookingRequest request)
{
    if (!_seats.TryHold(request.Seats))
    {
        return new BookingResult(Confirmed: false, ChargedPence: 0);
    }

    int full = _pricer.PriceInPence(request.Seats);
    int percentOff = _discount.PercentOff(request.Student);
    int total = full - full * percentOff / 100;

    if (!_payments.TryCharge(request.Email, total))
    {
        _seats.Release(request.Seats);
        return new BookingResult(Confirmed: false, ChargedPence: 0);
    }

    _confirmations.Send(request.Email, total);
    return new BookingResult(Confirmed: true, ChargedPence: total);
}
