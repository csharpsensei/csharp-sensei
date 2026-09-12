namespace TailSampling.Sampling;

/// <summary>
/// A small seeded pseudo-random source, so this sample prints the same numbers
/// on your machine as it does in the lesson.
///
/// A real head sampler hashes the trace id and keeps a fixed fraction of the
/// hash space. That is genuinely random per run, which is correct in
/// production and useless in a demonstration, so this stands in for it. It is
/// the only place the sample departs from what you would ship.
/// </summary>
public sealed class Deterministic
{
    private ulong _state;

    public Deterministic(ulong seed) => _state = seed;

    /// <summary>A value in the range zero up to, but not including, bound.</summary>
    public int Next(int bound)
    {
        _state = _state * 6364136223846793005UL + 1442695040888963407UL;
        return (int)((_state >> 33) % (ulong)bound);
    }
}
