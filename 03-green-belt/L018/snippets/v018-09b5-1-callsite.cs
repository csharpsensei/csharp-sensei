    private static void FactoryPass()
    {
        Console.WriteLine("Pass 2: same output, one place decides");

        IExporter exporter = ExporterFactory.For("csv");

        Console.WriteLine("  " + exporter.FileName);
        foreach (string line in exporter.Render(Warehouse.Counted))
        {
            Console.WriteLine("  " + line);
        }
    }
