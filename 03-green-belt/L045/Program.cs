using Shop.Orders;
using Shop.Stock;

var orders = new OrderService();
orders.Subscribe(new EmailSender());
orders.Subscribe(new Warehouse());
orders.Subscribe(new LoyaltyScheme());
orders.Subscribe(new AuditLog());
orders.Place(new Order(1, "Asha", 40m));

var kettle = new StockItem("kettle");

void TellAsha(string item) =>
    Console.WriteLine($"asha: {item} is back");

kettle.BackInStock += TellAsha;
kettle.BackInStock += item =>
    Console.WriteLine($"shop: show {item} again");
kettle.Restock(5);

kettle.BackInStock -= TellAsha;
kettle.Sell(5);
kettle.Restock(2);
