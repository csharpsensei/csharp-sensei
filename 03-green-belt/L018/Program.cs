using FactoryPattern.Exporting;
using FactoryPattern.Jobs;
using FactoryPattern.Legacy;
using FactoryPattern.Stock;

namespace FactoryPattern;

public static class Program
{
    public static void Main()
    {
        HandRolledPass();
        Console.WriteLine();
        FactoryPass();
        Console.WriteLine();
        FactoryMethodPass();
    }

    /// <summary>The format chosen at the call site, twice. Do not copy.</summary>
    private static void HandRolledPass()
    {
        Console.WriteLine("Pass 1: the format chosen at the call site (do not copy)");

        // Measured rather than asserted: the on-demand export and the nightly
        // backup hold the same decision, written out twice.
        bool duplicated = HandRolledExport.Run("csv")
                                          .Skip(1)
                                          .SequenceEqual(NightlyBackup.Run("csv"));

        Console.WriteLine("  NightlyBackup.cs holds the same decision: " + duplicated);
        foreach (string line in HandRolledExport.Run("csv"))
        {
            Console.WriteLine("  " + line);
        }
    }

    /// <summary>
    /// One place decides. The call site names a format and never an
    /// implementation, and the printed rows are identical to pass 1.
    /// </summary>
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

    /// <summary>
    /// Factory Method. Each job owns the answer to which exporter it needs, and
    /// the shared steps are written once in the base class.
    /// </summary>
    private static void FactoryMethodPass()
    {
        Console.WriteLine("Pass 3: each job builds its own exporter");

        ExportJob[] jobs = { new AuditExportJob(), new BackupExportJob() };

        foreach (ExportJob job in jobs)
        {
            foreach (string line in job.Run())
            {
                Console.WriteLine("  " + line);
            }
        }
    }
}
