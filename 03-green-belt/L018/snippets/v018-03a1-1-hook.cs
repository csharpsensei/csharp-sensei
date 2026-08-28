    public static IEnumerable<string> Run(string format)
    {
        // The decision about which concrete exporter to build, written inline.
        if (format == "csv")
        {
            yield return "stocktake.csv";
            yield return "sku,name,count";
            foreach (StockLine line in Warehouse.Counted)
            {
                yield return line.Sku + "," + line.Name + "," + line.Count;
            }
        }
        else if (format == "json")
