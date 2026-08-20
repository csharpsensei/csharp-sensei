namespace InterfaceSegregation.Storage;

public interface IManageAccess
{
    void Snapshot(string destination);

    void SetAccess(string user, bool canWrite);
}
