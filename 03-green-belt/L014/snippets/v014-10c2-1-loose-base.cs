// DO NOT COPY
public abstract class LooseNotifier
{
    public abstract void Send(string recipient, string message);
}

public sealed class LooseSmsNotifier : LooseNotifier
{
    public override void Send(string recipient, string message)
    {
    }
}
