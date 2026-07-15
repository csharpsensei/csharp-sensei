// THE BAD SMELL — everything crammed into one block, logic copy-pasted

int price = 5;
int quantity = 3;
int total = price * quantity;          // the calculation...
Console.WriteLine($"Total: {total}");

int bulkPrice = 12;
int bulkQuantity = 40;
int bulkTotal = bulkPrice * bulkQuantity;   // ...copy-pasted again
Console.WriteLine($"Bulk order: {bulkTotal}");

// Need it a third time? Copy-paste again. Logic changes? Fix it everywhere.














