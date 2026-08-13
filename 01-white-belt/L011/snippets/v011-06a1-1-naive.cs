public enum DeviceType { Tv, Soundbar, BluRayPlayer }

public static class NaiveDispatch
{
    public static void Power(DeviceType type)
    {
        if (type == DeviceType.Tv)
        {
            Console.WriteLine("Tv: warming up the panel, switching to the last input.");
        }
        else if (type == DeviceType.Soundbar)
        {
            Console.WriteLine("Soundbar: powering on, restoring last night's volume.");
        }
        else if (type == DeviceType.BluRayPlayer)
        {
            Console.WriteLine("BluRayPlayer: spinning up the drive at the standard speed.");
        }
        else
        {
            // A fourth device arrives here and matches nothing. No error.
            // No crash. The button just does not work.
        }
    }
}
