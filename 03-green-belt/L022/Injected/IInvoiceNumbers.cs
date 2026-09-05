namespace SingletonPattern.Injected;

/// <summary>
/// The seam. Once the number source has a name, a caller can be handed one,
/// a test can be handed a different one, and the application decides how many
/// exist instead of the class deciding for it.
/// </summary>
public interface IInvoiceNumbers
{
    string Next();
}
