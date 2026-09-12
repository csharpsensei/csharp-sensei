using System.Diagnostics;

namespace TailSampling.Sampling;

/// <summary>
/// The decision, taken with the finished trace in front of it. Four rules,
/// tried in order, first match wins.
///
/// This is a hand written version of what the OpenTelemetry collector's tail
/// sampling processor does from a list of policies in YAML. The rules are the
/// interesting part, and they are yours either way.
/// </summary>
public sealed class TailPolicy
{
    /// <summary>Anything at or over this counts as slow.</summary>
    public const int SlowMilliseconds = 10;

    private const int BaselineOneIn = 20;

    private readonly Deterministic _rng = new Deterministic(7);
    private readonly bool _businessTagsVisible;

    public TailPolicy(bool businessTagsVisible)
        => _businessTagsVisible = businessTagsVisible;

    public Decision Judge(Activity trace)
    {
        if (trace.Status == ActivityStatusCode.Error)
        {
            return Decision.Error;
        }

        if (trace.Duration.TotalMilliseconds >= SlowMilliseconds)
        {
            return Decision.Slow;
        }

        if (IsWatched(trace))
        {
            return Decision.Vip;
        }

        bool keep = _rng.Next(BaselineOneIn) == 0;
        return keep ? Decision.Baseline : Decision.Dropped;
    }

    /// <summary>
    /// The rule that needs an attribute nobody else was ever going to set.
    /// </summary>
    private bool IsWatched(Activity trace)
        => _businessTagsVisible
        && (trace.GetTagItem("customer.tier") as string) == "vip";
}
