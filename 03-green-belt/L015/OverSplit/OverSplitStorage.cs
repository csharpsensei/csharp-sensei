namespace InterfaceSegregation.OverSplit;

// DO NOT COPY. One method per interface. By the letter of the principle this
// is flawless: no caller depends on a method it does not call, because no
// interface has a spare method in it to depend on.
//
// The one line form is deliberate and is a demo simplification, named here
// rather than hidden (PRODUCTION-SYSTEM.md §16.3). It exists so all five fit
// on one still and the shape is visible at a glance. Do not write production
// interfaces on one line.

public interface IReadOneFile { byte[] Read(string name); }

public interface IWriteOneFile { void Write(string n, byte[] c); }

public interface IDeleteOneFile { void Delete(string name); }

public interface IListFileNames { IReadOnlyList<string> List(); }

public interface IGrantAccess { void SetAccess(string u, bool w); }

/// <summary>
/// DO NOT COPY. Read the four parameters and try to say, in one sentence,
/// what this class is for. The constructor describes plumbing instead of a
/// role, which is the cost the wide interface was supposed to have fixed.
/// </summary>
public sealed class FileCopier
{
    private readonly IReadOneFile _reader;
    private readonly IWriteOneFile _writer;
    private readonly IListFileNames _lister;
    private readonly IGrantAccess _access;

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

    public void Copy(string name)
    {
        _writer.Write(name, _reader.Read(name));
    }
}
