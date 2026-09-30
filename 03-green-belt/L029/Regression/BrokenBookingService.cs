using ComponentTests.App.Booking;
using ComponentTests.App.Ports;
using ComponentTests.App.Pricing;

namespace ComponentTests.Regression;

/// <summary>
/// DO NOT COPY THIS SHAPE. The booking service with one line wrong: it takes
/// the discount's percentage away as if it were pence. Every class it uses
/// passes its own unit tests. It exists so the lesson can show a component
/// test catching what those unit tests cannot.
/// </summary>
public sealed class BrokenBookingService
{
    private readonly TicketPricer _pricer;
    private readonly StudentDiscount _discount;
    private readonly ISeatStore _seats;
    private readonly IPaymentGateway _payments;
    private readonly IConfirmationSender _confirmations;

    public BrokenBookingService(
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
        int total = full - percentOff;

        if (!_payments.TryCharge(request.Email, total))
        {
            _seats.Release(request.Seats);
            return new BookingResult(Confirmed: false, ChargedPence: 0);
        }

        _confirmations.Send(request.Email, total);
        return new BookingResult(Confirmed: true, ChargedPence: total);
    }
}
