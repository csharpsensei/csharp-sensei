using System.Collections.Concurrent;

namespace AsyncDeadlock.Threading;

/// <summary>
/// A SynchronizationContext with exactly one thread, the way a desktop UI
/// thread works: anything posted to it runs on that thread, one at a time,
/// in order. Written for the lesson so the deadlock can be shown in a console
/// app, which has no context of its own. A simplification named in the README.
/// </summary>
public sealed class SingleThreadContext : SynchronizationContext
{
    private readonly BlockingCollection<(SendOrPostCallback, object?)> _queue =
        new BlockingCollection<(SendOrPostCallback, object?)>();

    private readonly Thread _thread;

    public SingleThreadContext()
    {
        _thread = new Thread(Pump) { IsBackground = true };
        _thread.Start();
    }

    public bool IsCurrentThread => Thread.CurrentThread == _thread;

    public override void Post(SendOrPostCallback callback, object? state) =>
        _queue.Add((callback, state));

    /// <summary>
    /// Starts the work ON the context thread and waits, from the calling
    /// thread, up to <paramref name="patience"/>. Null means it never finished.
    /// </summary>
    public string? Run(Func<Task<string>> work, TimeSpan patience)
    {
        var done = new TaskCompletionSource<string>(
            TaskCreationOptions.RunContinuationsAsynchronously);

        Post(_ =>
        {
            work().ContinueWith(finished =>
            {
                if (finished.IsFaulted)
                    done.SetException(finished.Exception!.InnerExceptions);
                else
                    done.SetResult(finished.Result);
            }, TaskScheduler.Default);
        }, null);

        return done.Task.Wait(patience) ? done.Task.Result : null;
    }

    private void Pump()
    {
        SetSynchronizationContext(this);
        foreach ((SendOrPostCallback callback, object? state)
                 in _queue.GetConsumingEnumerable())
        {
            callback(state);
        }
    }
}
