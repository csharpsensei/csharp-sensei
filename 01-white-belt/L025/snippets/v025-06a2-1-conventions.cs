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
