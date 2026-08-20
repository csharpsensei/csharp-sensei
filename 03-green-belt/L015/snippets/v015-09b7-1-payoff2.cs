// What the fix was not: no new layer, no factory, no base class and
// no adapter. One interface with six members became three interfaces
// with six members between them, and every member landed on the class
// that already had it.
private static void SplitPass(string root)
{
    DiskFileStore disk = new DiskFileStore(root);
    PackageStore package = new PackageStore();
