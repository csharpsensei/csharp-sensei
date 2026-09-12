using System.Diagnostics;

namespace TailSampling.Sampling;

/// <summary>
/// Head sampling. The decision is taken in the Sample callback, which .NET
/// runs BEFORE the activity object exists.
///
/// Return None and StartActivity hands the caller back null. There is nothing
/// to tag, nothing to time, and nothing that can change its mind when the
/// request turns out to have failed.
/// </summary>
public sealed class HeadSampler : IDisposable
{
    private readonly ActivityListener _listener;
    private readonly Deterministic _rng = new Deterministic(11);

    public HeadSampler(string sourceName, int oneIn)
    {
        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == sourceName,

            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
                _rng.Next(oneIn) == 0
                    ? ActivitySamplingResult.AllDataAndRecorded
                    : ActivitySamplingResult.None,

            ActivityStopped = activity => Recorded.Add(activity)
        };

        ActivitySource.AddActivityListener(_listener);
    }

    /// <summary>The activities that were allowed to exist at all.</summary>
    public List<Activity> Recorded { get; } = new List<Activity>();

    public void Dispose() => _listener.Dispose();
}
