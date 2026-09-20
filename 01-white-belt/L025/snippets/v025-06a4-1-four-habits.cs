public sealed class BadNames
{
    private readonly List<Loan> loanList = new List<Loan>();

    private int ovrdCnt;

    private string strMemberName = string.Empty;

    public void Add(Loan l, bool f)
    {
        loanList.Add(l);
