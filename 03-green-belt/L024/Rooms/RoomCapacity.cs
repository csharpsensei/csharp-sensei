namespace BuilderPattern.Rooms;

/// <summary>
/// How many people a room type sleeps. A pure lookup with no state of its own,
/// so it is a static class without any of the arguments that came with the
/// previous lesson's static state.
/// </summary>
public static class RoomCapacity
{
    public static int Of(RoomType room) => room switch
    {
        RoomType.Single => 1,
        RoomType.Double => 2,
        RoomType.Family => 4,
        _ => 0
    };
}
