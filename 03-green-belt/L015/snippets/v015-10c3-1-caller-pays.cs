public sealed class FileCopier
{
    public FileCopier(IReadOneFile reader,
                      IWriteOneFile writer,
                      IListFileNames lister,
                      IGrantAccess access)
    {
        _reader = reader;
        _writer = writer;
        _lister = lister;
        _access = access;
    }
}
