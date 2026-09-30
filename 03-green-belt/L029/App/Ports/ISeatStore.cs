namespace ComponentTests.App.Ports;

/// <summary>
/// The edge where seats are kept. In the real system this is a database.
/// </summary>
public interface ISeatStore
{
    bool TryHold(int seats);

    void Release(int seats);
}
