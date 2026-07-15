// MISTAKE 2 — void when you actually need a result back

void CalculateTotalBad(int price, int quantity)  // nothing comes back
{
    int total = price * quantity;                // trapped inside
}

int CalculateTotal(int price, int quantity)      // hands the result back
{
    return price * quantity;
}
