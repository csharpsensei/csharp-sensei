namespace LiskovSubstitution.Notifications;

/// <summary>
/// THE CONTRACT. This is what a caller holding a Notifier is entitled to
/// rely on, whatever it is really holding.
///
///   ACCEPTS  any recipient, and any message of one character or more.
///   RETURNS  a Receipt whose Delivered flag is true only if the message
///            reached the recipient.
///   THROWS   nothing for a message this contract accepts.
///
/// Written down on purpose. A promise nobody wrote down is a promise every
/// subclass gets to interpret for itself, which is how the two classes in
/// Legacy/ came to exist.
/// </summary>
public abstract class Notifier
{
    /// <summary>Which channel this notifier speaks for.</summary>
    public abstract string Channel { get; }

    /// <summary>Sends the message. See the contract on this class.</summary>
    public abstract Receipt Send(string recipient, string message);
}
