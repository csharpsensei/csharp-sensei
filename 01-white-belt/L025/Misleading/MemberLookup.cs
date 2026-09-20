using NamingAndComments.Lending;

namespace NamingAndComments.Misleading;

/// <summary>
/// The method below is called Get and it writes. Kept, misnamed, on purpose,
/// so the lesson can run it and show the write happening.
/// </summary>
public sealed class MemberLookup
{
    private readonly List<Member> _members;

    public MemberLookup(List<Member> members)
    {
        _members = members;
    }

    public Member GetMemberRecord(string name, DateOnly today)
    {
        foreach (Member member in _members)
        {
            if (member.Name == name)
            {
                member.LastSeenOn = today;

                return member;
            }
        }

        throw new KeyNotFoundException("No member called " + name);
    }
}
