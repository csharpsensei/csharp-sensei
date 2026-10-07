namespace IntegrationTests.App.Members;

/// <summary>
/// A member of the climbing centre: a name, and the email address they sign
/// in with. The email is the member's key.
/// </summary>
public sealed record Member(string Name, string Email);
