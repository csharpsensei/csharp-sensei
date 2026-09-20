namespace NamingAndComments.Lending;

public sealed class Loan
{
    public Loan(string title, string memberName, DateOnly dueOn, bool returned)
    {
        Title = title;
        MemberName = memberName;
        DueOn = dueOn;
        Returned = returned;
    }

    public string Title { get; }

    public string MemberName { get; }

    public DateOnly DueOn { get; }

    public bool Returned { get; }
}
