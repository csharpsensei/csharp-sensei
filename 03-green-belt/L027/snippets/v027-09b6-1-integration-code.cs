public async Task LoadAsync_AfterSaveAsync_ReturnsTheSameQuote()
{
    // Arrange
    Quote saved = new(
        Guid.NewGuid(), Grams: 1500, Express: true, PriceInPence: 800);
    await new JsonQuoteStore(_folder).SaveAsync(saved);
    JsonQuoteStore freshStore = new(_folder);

    // Act
    Quote? loaded = await freshStore.LoadAsync(saved.Id);

    // Assert
    Assert.Equal(saved, loaded);
}
