public class Report
{
    public decimal Total
    {
        get
        {
            var rows = _database.LoadAllRows();
            return rows.Sum(r => r.Amount);
        }
    }
}
