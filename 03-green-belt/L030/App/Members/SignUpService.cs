namespace IntegrationTests.App.Members;

/// <summary>
/// The front door for joining the climbing centre. It tidies what the person
/// typed and hands the new member to the store.
/// </summary>
public sealed class SignUpService
{
    private readonly IMemberStore _members;

    public SignUpService(IMemberStore members)
    {
        _members = members;
    }

    public bool SignUp(string name, string email)
    {
        Member member = new(name.Trim(), EmailAddress.Normalise(email));
        return _members.TryAdd(member);
    }
}
