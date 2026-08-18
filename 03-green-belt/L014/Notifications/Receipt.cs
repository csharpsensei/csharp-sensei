namespace LiskovSubstitution.Notifications;

/// <summary>
/// What a notifier hands back.
///
/// Delivered is true ONLY when the message reached the recipient on that
/// channel. That sentence is part of the contract in Notifier, so any
/// subclass returning true without sending anything is breaking it.
/// </summary>
public sealed record Receipt(string Channel, bool Delivered, string Note);
