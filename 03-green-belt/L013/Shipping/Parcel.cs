namespace OpenClosed.Shipping;

/// <summary>
/// The thing being priced. This is the part that does NOT vary: every
/// carrier prices the same parcel, so the parcel never needed a seam.
/// </summary>
public record Parcel(decimal WeightKg, string Destination);
