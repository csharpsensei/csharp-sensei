using InterfaceSegregation.Legacy;
using InterfaceSegregation.Publishing;
using InterfaceSegregation.Storage;
using InterfaceSegregation.Thumbnails;

namespace InterfaceSegregation;

public static class Program
{
    public static void Main()
    {
        string root = Path.Combine(Path.GetTempPath(), "L015-demo");
        Directory.CreateDirectory(root);
        File.WriteAllBytes(Path.Combine(root, "cover.png"), new byte[256]);

        LegacyPass(root);
        Console.WriteLine();
        SplitPass(root);
    }

    /// <summary>Cycle a. One wide interface. Do not copy.</summary>
    private static void LegacyPass(string root)
    {
        Console.WriteLine("Pass 1: one wide interface (do not copy)");

        IFileStore[] stores = { new LegacyPackageStore(), new LegacyDiskStore(root) };
        foreach (IFileStore store in stores)
        {
            string name = store.GetType().Name;
            string file = store is LegacyPackageStore ? "logo.png" : "cover.png";

            Report(name, "read", () => $"{store.Read(file).Length} bytes");
            Report(name, "write", () =>
            {
                store.Write("cover.thumb.png", new byte[64]);
                return "64 bytes written";
            });
        }

        // All four throwing methods match the interface exactly. Shape is
        // the only thing the compiler checks, and the shape is fine.
    }

    /// <summary>Cycle b. Three interfaces, split by what the caller does.</summary>
    // What the fix was not: no new layer, no factory, no base class and
    // no adapter. One interface with six members became three interfaces
    // with six members between them, and every member landed on the class
    // that already had it.
    private static void SplitPass(string root)
    {
        Console.WriteLine("Pass 2: interfaces split by what the caller does");

        DiskFileStore disk = new DiskFileStore(root);
        PackageStore package = new PackageStore();

        ThumbnailMaker fromDisk = new ThumbnailMaker(disk);
        ThumbnailMaker fromPackage = new ThumbnailMaker(package);
        Console.WriteLine(Row("ThumbnailMaker", "DiskFileStore", fromDisk.Shrink("cover.png")));
        Console.WriteLine(Row("ThumbnailMaker", "PackageStore", fromPackage.Shrink("logo.png")));

        Publisher publisher = new Publisher(disk);
        Console.WriteLine(Row("Publisher", "DiskFileStore", publisher.Publish("cover.thumb.png")));

        // Publisher wrong = new Publisher(package);
        // That line does not compile. PackageStore implements IReadFiles and
        // nothing else, so it is not an IWriteFiles. Uncomment it and the
        // failure arrives from the compiler instead of from a customer.
        Console.WriteLine("  PackageStore is not an IWriteFiles, so Publisher will not take it.");
        Console.WriteLine("  That line is commented out in Program.cs. Uncomment it to see.");
    }

    private static string Row(string caller, string store, string result)
        => $"  {caller,-16}{store,-16}{result}";

    private static void Report(string store, string action, Func<string> work)
    {
        try
        {
            Console.WriteLine($"  {store,-20}{action,-8}{work()}");
        }
        catch (NotImplementedException ex)
        {
            Console.WriteLine($"  {store,-20}{action,-8}THREW {ex.GetType().Name}");
        }
    }
}
