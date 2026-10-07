public void TryAdd_SameEmailTwice_ReturnsFalse()
{
    // Arrange
    SqliteMemberStore store = new(_connectionString);
    store.TryAdd(new Member("Sam Lee", "sam@example.com"));

    // Act
    bool added = store.TryAdd(new Member("Sam Lowe", "sam@example.com"));

    // Assert
    Assert.False(added);
}
