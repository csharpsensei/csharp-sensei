using EndToEndTests.App.Bookings;

namespace EndToEndTests.Tests.Component;

/// <summary>
/// Component tests: the booking service and the store it really uses,
/// together, with no web server and no HTTP.
/// </summary>
[Trait("Kind", "Component")]
public sealed class BookingServiceTests
{
    private static readonly DateOnly Monday = new(2026, 11, 2);

    [Fact]
    public void Book_FreeDay_CanBeFoundAgain()
    {
        // Arrange
        BookingService service = new(new InMemoryBookingStore());

        // Act
        Booking? booked = service.Book("  Ada Byrne ", Monday);

        // Assert
        Assert.Equal(new Booking(booked!.Id, "Ada Byrne", Monday), service.Find(booked.Id));
    }

    [Fact]
    public void Book_DayAlreadyTaken_ReturnsNull()
    {
        // Arrange
        BookingService service = new(new InMemoryBookingStore());
        service.Book("Ada Byrne", Monday);

        // Act
        Booking? second = service.Book("Ben Okafor", Monday);

        // Assert
        Assert.Null(second);
    }
}
