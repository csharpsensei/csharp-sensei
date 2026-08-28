    public static IEnumerable<string> Run(string format)
    {
        // The same decision again. Add a third format and BOTH files change,
        // or one of them is quietly left behind.
        if (format == "csv")
        {
            yield return "sku,name,count";
            foreach (StockLine line in Warehouse.Counted)
            {
                yield return line.Sku + "," + line.Name + "," + line.Count;
            }
        }
        else if (format == "json")
