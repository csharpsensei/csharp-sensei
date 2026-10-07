using IntegrationTests.App.Members;
using IntegrationTests.Tests.Fakes;

namespace IntegrationTests.Tests.Component;

/// <summary>
/// Component tests: sign up through its front door, with the real email rule
/// inside and a stand in where the database would be.
/// </summary>
[Trait("Kind", "Component")]
public sealed class SignUpServiceTests
{
    [Fact]
    public void SignUp_NewMember_AddsTheTidiedMember()
    {
        // Arrange
        FakeMemberStore members = new();
        SignUpService signUp = new(members);

        // Act
        signUp.SignUp("Sam Lee", " Sam@Example.com");

        // Assert
        Assert.Equal(new Member("Sam Lee", "sam@example.com"), Assert.Single(members.Added));
    }

    [Fact]
    public void SignUp_EmailAlreadyTaken_ReturnsFalse()
    {
        // Arrange
        FakeMemberStore members = new() { AlreadyTaken = true };
        SignUpService signUp = new(members);

        // Act
        bool joined = signUp.SignUp("Sam Lee", "sam@example.com");

        // Assert
        Assert.False(joined);
    }
}
