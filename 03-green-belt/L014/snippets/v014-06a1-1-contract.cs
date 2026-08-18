/// ACCEPTS  any recipient, and any message of one
///          character or more.
/// RETURNS  a Receipt whose Delivered flag is true only
///          if the message reached the recipient.
/// THROWS   nothing for a message this contract accepts.
public abstract class Notifier
{
    public abstract string Channel { get; }

    public abstract Receipt Send(string recipient,
                                 string message);
}
