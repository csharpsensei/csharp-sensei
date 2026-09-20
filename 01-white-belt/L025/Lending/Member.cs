namespace NamingAndComments.Lending;

public sealed class Member
{
    public Member(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public DateOnly? LastSeenOn { get; set; }
}
