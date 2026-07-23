public interface ISingletonStamp { string Id { get; } }
public interface IScopedStamp    { string Id { get; } }
public interface ITransientStamp { string Id { get; } }

public sealed class SingletonStamp : ISingletonStamp
{
    public string Id { get; } = Guid.NewGuid().ToString()[..4];
}

public sealed class ScopedStamp : IScopedStamp
{
    public string Id { get; } = Guid.NewGuid().ToString()[..4];
}

public sealed class TransientStamp : ITransientStamp
{
    public string Id { get; } = Guid.NewGuid().ToString()[..4];
}
