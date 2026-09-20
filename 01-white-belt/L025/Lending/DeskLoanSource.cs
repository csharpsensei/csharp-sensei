namespace NamingAndComments.Lending;

public sealed class DeskLoanSource : ILoanSource
{
    private readonly List<Loan> _loans;

    public DeskLoanSource(List<Loan> loans)
    {
        _loans = loans;
    }

    public List<Loan> OpenLoans()
    {
        List<Loan> stillOut = new List<Loan>();

        foreach (Loan loan in _loans)
        {
            if (!loan.Returned)
            {
                stillOut.Add(loan);
            }
        }

        return stillOut;
    }
}
