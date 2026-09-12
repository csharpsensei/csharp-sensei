namespace TailSampling.Sampling;

/// <summary>Why a finished trace was kept, or that it was not kept at all.</summary>
public enum Decision
{
    Dropped,
    Error,
    Slow,
    Vip,
    Baseline
}
