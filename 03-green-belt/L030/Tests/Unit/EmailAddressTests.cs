using IntegrationTests.App.Members;

namespace IntegrationTests.Tests.Unit;

/// <summary>
/// Unit tests: the email rule on its own. No database, no store.
/// </summary>
[Trait("Kind", "Unit")]
public sealed class EmailAddressTests
{
    [Fact]
    public void Normalise_MixedCase_ReturnsLowerCase()
    {
        // Arrange
        string typed = "Sam@Example.com";

        // Act
        string normalised = EmailAddress.Normalise(typed);

        // Assert
        Assert.Equal("sam@example.com", normalised);
    }

    [Fact]
    public void Normalise_SurroundingSpaces_TrimsThem()
    {
        // Arrange
        string typed = "  sam@example.com ";

        // Act
        string normalised = EmailAddress.Normalise(typed);

        // Assert
        Assert.Equal("sam@example.com", normalised);
    }
}
