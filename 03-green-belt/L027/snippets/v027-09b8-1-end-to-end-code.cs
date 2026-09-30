// Arrange
QuoteRequest request = new(Grams: 1500, Express: true);
HttpResponseMessage posted =
    await _client!.PostAsJsonAsync("/quotes", request);
Quote? created = await posted.Content.ReadFromJsonAsync<Quote>();

// Act
Quote? fetched =
    await _client.GetFromJsonAsync<Quote>($"/quotes/{created!.Id}");

// Assert
Assert.Equal(800, fetched!.PriceInPence);
