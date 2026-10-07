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
