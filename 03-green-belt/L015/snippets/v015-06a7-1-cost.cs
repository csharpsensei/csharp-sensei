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
