using SingleResponsibility.Legacy;
using SingleResponsibility.Invoicing;
using SingleResponsibility.OverSplit;

// Composition root. Three passes, matching the lesson's three cycles.

// Pass 1: the violation. One class, three jobs, all of them working.
var god = new InvoiceGodClass("Alicia Novak");
god.AddLine("Keyboard", 2, 45.00m);
god.AddLine("Monitor Stand", 1, 89.00m);
Console.WriteLine(god.PrintReceipt());
god.Save();

Console.WriteLine();

// Pass 2: the refactor. Same output, three collaborators, each with one job.
var invoice = new Invoice("Alicia Novak", new[]
{
    ("Keyboard", 2, 45.00m),
    ("Monitor Stand", 1, 89.00m),
});
var calculator = new InvoiceCalculator();
var printer = new InvoicePrinter(calculator);
var repository = new InvoiceRepository(calculator);

Console.WriteLine(printer.Print(invoice));
repository.Save(invoice);

Console.WriteLine();

// Pass 3: the boundary. The over-split version still works, and still
// produces the right number, but now four classes exist to answer one
// question that InvoiceCalculator alone already answered.
var totalCalculator = new TotalCalculator();
Console.WriteLine($"[over-split] total via TotalCalculator: {totalCalculator.Calculate(invoice):C}");
