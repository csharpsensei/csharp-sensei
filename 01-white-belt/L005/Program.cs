using L005;

// ============================================================
// CONSTRUCTORS — valid birth enforced
// ============================================================
Console.WriteLine("=== Constructors ===");

var alice = new BankAccount("Alice", 500m);
var bob   = new BankAccount("Bob");          // convenience ctor, zero balance
Console.WriteLine(alice);
Console.WriteLine(bob);
Console.WriteLine($"Accounts opened: {BankAccount.AccountCount}");

// This won't compile — no parameterless constructor:
// var bad = new BankAccount();

// This throws at construction — never reaches an invalid state:
try
{
    var invalid = new BankAccount("", 100m);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

try
{
    var negative = new BankAccount("Carol", -1m);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

// ============================================================
// ACCESS MODIFIERS — valid life enforced
// ============================================================
Console.WriteLine("\n=== Access Modifiers ===");

alice.Deposit(200m);
Console.WriteLine($"After deposit: {alice.Balance:C}");

alice.Withdraw(100m);
Console.WriteLine($"After withdrawal: {alice.Balance:C}");

// alice.Balance = -9999m;   // CS0272 — private setter, won't compile

try
{
    alice.Withdraw(10_000m);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Caught: {ex.Message}");
}

// ============================================================
// STATIC MEMBERS — type-level data and behaviour
// ============================================================
Console.WriteLine("\n=== Static Members ===");

var dave = new BankAccount("Dave", 1000m);
Console.WriteLine($"Total accounts: {BankAccount.AccountCount}");      // 3
Console.WriteLine($"Minimum balance: {BankAccount.MinimumBalance:C}");
Console.WriteLine($"Is 500 valid? {BankAccount.IsValidOpeningBalance(500m)}");
Console.WriteLine($"Is -1 valid?  {BankAccount.IsValidOpeningBalance(-1m)}");
