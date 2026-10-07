public void FindByEmail_AfterTryAdd_ReturnsTheSameMember()
{
    // Arrange
    Member added = new("Sam Lee", "sam@example.com");
    new SqliteMemberStore(_connectionString).TryAdd(added);
    SqliteMemberStore freshStore = new(_connectionString);

    // Act
    Member? found = freshStore.FindByEmail("sam@example.com");

    // Assert
    Assert.Equal(added, found);
}
