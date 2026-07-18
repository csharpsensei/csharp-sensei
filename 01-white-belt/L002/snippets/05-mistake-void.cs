    
    // MISTAKE 2 — void when you actually need a result back

    void CalculateTotalBad(int price, int quantity)  // nothing returned
    {
        int total = price * quantity;                // trapped inside
    }

    int CalculateTotal(int price, int quantity)      // returns the result
    {
        return price * quantity;
    }













