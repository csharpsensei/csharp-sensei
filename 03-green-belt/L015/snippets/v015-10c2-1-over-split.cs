public interface IReadOneFile { byte[] Read(string name); }

public interface IWriteOneFile { void Write(string n, byte[] c); }

public interface IDeleteOneFile { void Delete(string name); }

public interface IListFileNames { IReadOnlyList<string> List(); }

public interface IGrantAccess { void SetAccess(string u, bool w); }
