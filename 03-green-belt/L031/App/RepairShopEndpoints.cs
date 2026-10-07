using EndToEndTests.App.Bookings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace EndToEndTests.App;

/// <summary>
/// The shop's two endpoints: book a repair, and look a booking up.
/// </summary>
public static class RepairShopEndpoints
{
    public static void Map(IEndpointRouteBuilder routes)
    {
        routes.MapPost("/bookings", (BookingRequest request, BookingService bookings) =>
        {
            if (string.IsNullOrWhiteSpace(request.Customer))
            {
                return Results.BadRequest("A booking needs a name.");
            }

            Booking? booking = bookings.Book(request.Customer, request.Day);
            return booking is null
                ? Results.Conflict("That day is already booked.")
                : Results.Created($"/bookings/{booking.Id}", booking);
        });

        routes.MapGet("/bookings/{id:guid}", (Guid id, BookingService bookings) =>
            bookings.Find(id) is Booking booking
                ? Results.Ok(booking)
                : Results.NotFound());
    }
}
