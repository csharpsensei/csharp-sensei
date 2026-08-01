Customer[] customers = new Customer[10];
int used = 0;

customers[used] = new Customer(1, "Aiko");
used++;

if (used == customers.Length)
{
    Array.Resize(ref customers, used * 2);
}
