public void Save()
{
    Console.WriteLine($"[db] saved invoice for {_customer}, " +
        $"total {CalculateTotal():C}");
}
