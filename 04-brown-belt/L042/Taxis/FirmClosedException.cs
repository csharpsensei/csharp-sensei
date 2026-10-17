namespace CoordinatingTasks.Taxis;

/// <summary>A firm that cannot take a booking at all.</summary>
public sealed class FirmClosedException(string firm)
    : Exception(firm + " is closed");
