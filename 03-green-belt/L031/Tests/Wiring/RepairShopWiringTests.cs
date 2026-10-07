using EndToEndTests.App;
using EndToEndTests.App.Bookings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace EndToEndTests.Tests.Wiring;

/// <summary>
/// The test pushed down after the end to end test found the wiring bug. It
/// builds the real application without starting it, and asks for the store
/// from two scopes, which is what two requests get. Fast, and it names the bug.
/// </summary>
[Trait("Kind", "Wiring")]
public sealed class RepairShopWiringTests
{
    [Fact]
    public void BookingStore_TwoRequests_ShareOneStore()
    {
        // Arrange
        using WebApplication app = RepairShopApi.Build("http://127.0.0.1:0");
        using IServiceScope firstRequest = app.Services.CreateScope();
        using IServiceScope secondRequest = app.Services.CreateScope();

        // Act
        bool shared = ReferenceEquals(
            firstRequest.ServiceProvider.GetRequiredService<IBookingStore>(),
            secondRequest.ServiceProvider.GetRequiredService<IBookingStore>());

        // Assert
        Assert.True(shared);
    }
}
