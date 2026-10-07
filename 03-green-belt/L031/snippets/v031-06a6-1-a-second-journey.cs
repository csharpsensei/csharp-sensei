public async Task Book_DayAlreadyTaken_ReturnsConflict()
{
    // Arrange
    await _client!.PostAsJsonAsync("/bookings", new BookingRequest("Ada Byrne", Monday));

    // Act
    HttpResponseMessage second = await _client.PostAsJsonAsync(
        "/bookings", new BookingRequest("Ben Okafor", Monday));

    // Assert
    Assert.Equal(HttpStatusCode.Conflict, second.StatusCode);
}
