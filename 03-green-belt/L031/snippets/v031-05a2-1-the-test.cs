public async Task GetBooking_AfterBookingIt_ReturnsTheBooking()
{
    // Arrange
    HttpResponseMessage posted = await _client!.PostAsJsonAsync(
        "/bookings", new BookingRequest("Ada Byrne", Monday));
    Booking? booked = await posted.Content.ReadFromJsonAsync<Booking>();

    // Act
    HttpResponseMessage fetched = await _client.GetAsync($"/bookings/{booked!.Id}");

    // Assert
    Assert.Equal(HttpStatusCode.OK, fetched.StatusCode);
    Assert.Equal(booked, await fetched.Content.ReadFromJsonAsync<Booking>());
}
