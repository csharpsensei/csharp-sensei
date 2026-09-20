using NamingAndComments.Lending;

namespace NamingAndComments.Unclear;

/// <summary>
/// A collection of the four naming habits the lesson names, kept in one real
/// class so the still is a slice of source rather than a picture somebody
/// typed. Do not copy any of it.
/// </summary>
public sealed class BadNames
{
    private readonly List<Loan> loanList = new List<Loan>();

    private int ovrdCnt;

    private string strMemberName = string.Empty;

    public void Add(Loan l, bool f)
    {
        loanList.Add(l);
        strMemberName = l.MemberName;

        if (f)
        {
            ovrdCnt = ovrdCnt + 1;
        }
    }

    public string Summary()
    {
        return loanList.Count + " for " + strMemberName + ", " + ovrdCnt + " flagged";
    }
}
