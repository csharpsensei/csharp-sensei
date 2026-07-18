public class Report
{
    public decimal CalculateTotal()
    {
        var rows = _database.LoadAllRows();
        return rows.Sum(r => r.Amount);
    }
}
