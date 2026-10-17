namespace AdapterPattern.Heating;

/// <summary>Our one way of saying "the thermostat refused that target".</summary>
public sealed class TargetRejectedException(string message)
    : Exception(message);
