namespace LockingAndPolymorphism.Legacy;

// The method from the start of the lesson (block 03a1 / 06a1). It compiles
// and runs — that is the whole problem. Every new device type means someone
// has to remember to come back HERE and add a branch. Miss one, and the
// branch that should have handled it silently does nothing. This file is
// demoed once in Program.cs and never touched again; everything after it in
// the video replaces this pattern rather than building on it.
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
            // A fourth device (SmartSpeaker) arrives here and matches nothing.
            // No error. No crash. The button just does not work.
        }
    }
}
