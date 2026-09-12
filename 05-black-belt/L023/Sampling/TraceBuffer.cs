using System.Diagnostics;

namespace TailSampling.Sampling;

/// <summary>
/// The other way round. Record everything, hold it, and judge it when it is
/// finished.
///
/// ActivityStopped is the callback that matters, because a trace cannot be
/// judged until it has ended. In production this buffer lives in the
/// collector rather than in the process being traced, and it is full whether
/// or not anything interesting happens in it. That is the price.
/// </summary>
public sealed class TraceBuffer : IDisposable
{
    private readonly ActivityListener _listener;

    public TraceBuffer(string sourceName)
    {
        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == sourceName,

            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
                ActivitySamplingResult.AllDataAndRecorded,

            ActivityStopped = activity => Completed.Add(activity)
        };

        ActivitySource.AddActivityListener(_listener);
    }

    /// <summary>Every finished trace, in the order it finished.</summary>
    public List<Activity> Completed { get; } = new List<Activity>();

    public void Dispose() => _listener.Dispose();
}
