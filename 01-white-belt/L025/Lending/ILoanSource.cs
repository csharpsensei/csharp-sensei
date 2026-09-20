namespace NamingAndComments.Lending;

public interface ILoanSource
{
    List<Loan> OpenLoans();
}
