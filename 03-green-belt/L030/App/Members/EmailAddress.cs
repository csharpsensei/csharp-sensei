namespace IntegrationTests.App.Members;

/// <summary>
/// One rule for what an email address looks like once it is stored: no
/// surrounding spaces, all lower case.
/// </summary>
public static class EmailAddress
{
    public static string Normalise(string email)
    {
        return email.Trim().ToLowerInvariant();
    }
}
