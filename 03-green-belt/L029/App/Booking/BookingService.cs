using ComponentTests.App.Ports;
using ComponentTests.App.Pricing;

namespace ComponentTests.App.Booking;

/// <summary>
/// The front door of the booking component. It holds the seats, prices them,
/// takes the payment and sends the confirmation, in that order, and gives the
/// seats back if the payment fails.
/// </summary>
public sealed class BookingService
{
    private readonly TicketPricer _pricer;
    private readonly StudentDiscount _discount;
    private readonly ISeatStore _seats;
    private readonly IPaymentGateway _payments;
    private readonly IConfirmationSender _confirmations;

    public BookingService(
        TicketPricer pricer,
        StudentDiscount discount,
        ISeatStore seats,
        IPaymentGateway payments,
        IConfirmationSender confirmations)
    {
        _pricer = pricer;
        _discount = discount;
        _seats = seats;
        _payments = payments;
        _confirmations = confirmations;
    }

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
}
