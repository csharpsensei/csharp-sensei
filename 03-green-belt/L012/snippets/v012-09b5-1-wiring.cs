var calculator = new InvoiceCalculator();
var printer = new InvoicePrinter(calculator);
var repository = new InvoiceRepository(calculator);

printer.Print(invoice);
repository.Save(invoice);
