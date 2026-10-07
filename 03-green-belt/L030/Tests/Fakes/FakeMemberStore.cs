using IntegrationTests.App.Members;

namespace IntegrationTests.Tests.Fakes;

/// <summary>
/// A stand in for the member database: a list in memory. It records what it
/// was given and hands back what the test told it to. It never runs any SQL,
/// which is exactly why it cannot tell you whether the SQL is right.
/// </summary>
public sealed class FakeMemberStore : IMemberStore
{
    public bool AlreadyTaken { get; init; }

    public List<Member> Added { get; } = new();

    public bool TryAdd(Member member)
    {
        if (AlreadyTaken)
        {
            return false;
        }

        Added.Add(member);
        return true;
    }

    public Member? FindByEmail(string email)
    {
        return Added.FirstOrDefault(member => member.Email == email);
    }
}
