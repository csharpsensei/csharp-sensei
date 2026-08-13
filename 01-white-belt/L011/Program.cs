// Program.cs is the composition root and nothing else (PRODUCTION-SYSTEM §16.2).
using LockingAndPolymorphism.Devices;
using LockingAndPolymorphism.Legacy;

Console.WriteLine("=== 1. The naive version (block 06a1) ===");
NaiveDispatch.Power(DeviceType.Tv);
NaiveDispatch.Power(DeviceType.Soundbar);
NaiveDispatch.Power(DeviceType.BluRayPlayer);

Console.WriteLine();
Console.WriteLine("=== 2. Polymorphism: same call, different behaviour (blocks 06a5-06a6) ===");
Device d = new Tv("Living Room Tv");
d.Power();
d = new Soundbar("Living Room Soundbar");
d.Power();

Console.WriteLine();
Console.WriteLine("=== 3. A fourth device, zero changes to the calling code (block 08a2) ===");
Device fourth = new SmartSpeaker("Kitchen Speaker");
fourth.Power();

Console.WriteLine();
Console.WriteLine("=== 4. The whole point, in one loop (blocks 09a1-09a3) ===");
List<Device> devices = new()
{
    new Tv("Living Room Tv"),
    new Soundbar("Living Room Soundbar"),
    new SmartSpeaker("Kitchen Speaker"),
};
foreach (Device device in devices)
{
    device.Power();
}

Console.WriteLine();
Console.WriteLine("=== 5. Sealed still works exactly the same way (block 12b3) ===");
List<Device> withSealed = new(devices) { new BluRayPlayer("Lounge Blu Ray Player") };
foreach (Device device in withSealed)
{
    device.Power();
}
