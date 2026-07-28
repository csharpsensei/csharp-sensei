namespace L005;

/// <summary>
/// A bank account that enforces valid state through constructors,
/// access modifiers, and uses static members for type-level data.
/// </summary>
public class BankAccount
{
    // ------------------------------------------------------------------ Fields
    private decimal _balance;
    private static int _accountCount = 0;

    // ---------------------------------------------------------------- Properties
    public string  Owner   { get; private set; }

    public decimal Balance
    {
        get => _balance;
        private set => _balance = value;
    }

    public static int AccountCount => _accountCount;

    public static readonly decimal MinimumBalance = 0m;

    // -------------------------------------------------------------- Constructors
    /// <summary>
    /// Primary constructor — validates and assigns in one step.
    /// No path to an invalid BankAccount exists.
    /// </summary>
    public BankAccount(string owner, decimal openingBalance)
    {
        if (string.IsNullOrWhiteSpace(owner))
            throw new ArgumentException("Owner is required.", nameof(owner));

        if (openingBalance < MinimumBalance)
            throw new ArgumentOutOfRangeException(
                nameof(openingBalance), "Opening balance cannot be negative.");

        Owner    = owner;
        _balance = openingBalance;
        _accountCount++;
    }

    /// <summary>
    /// Convenience constructor — chains to the primary with a zero balance.
    /// </summary>
    public BankAccount(string owner) : this(owner, 0m) { }

    // ------------------------------------------------------------------ Methods
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.", nameof(amount));

        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal amount must be positive.", nameof(amount));

        if (amount > _balance)
            throw new InvalidOperationException("Insufficient funds.");

        _balance -= amount;
    }

    public static bool IsValidOpeningBalance(decimal amount) => amount >= MinimumBalance;

    public override string ToString() =>
        $"BankAccount {{ Owner = {Owner}, Balance = {Balance:C} }}";
}
