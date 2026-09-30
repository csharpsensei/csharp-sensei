using ComponentTests.App.Ports;

namespace ComponentTests.Tests.Fakes;

/// <summary>
/// A stand in for the seat database: a number in memory. It works, it is
/// just not something you would ship.
/// </summary>
public sealed class FakeSeatStore : ISeatStore
{
    public FakeSeatStore(int available)
    {
        Available = available;
    }

    public int Available { get; private set; }

    public bool TryHold(int seats)
    {
        if (seats > Available)
        {
            return false;
        }

        Available -= seats;
        return true;
    }

    public void Release(int seats)
    {
        Available += seats;
    }
}
