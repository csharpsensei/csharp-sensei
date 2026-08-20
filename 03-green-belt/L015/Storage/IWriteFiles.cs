namespace InterfaceSegregation.Storage;

public interface IWriteFiles
{
    void Write(string name, byte[] content);

    void Delete(string name);
}
