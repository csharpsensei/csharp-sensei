namespace WideEvents.Events;

/// <summary>
/// Reaches the request's <see cref="WideEvent"/> from anywhere in the pipeline
/// without threading a parameter through every method signature.
///
/// Lives beside <see cref="WideEvent"/> rather than in a general Extensions/
/// folder: it exists only to serve this type, so cohesion beats grouping by
/// technical kind.
/// </summary>
public static class WideEventExtensions
{
    internal const string ItemsKey = "wide-event";

    /// <summary>
    /// The wide event for the current request.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when <see cref="WideEventMiddleware"/> is not in the pipeline.
    /// Failing loudly here beats silently dropping fields — a wide event that
    /// quietly loses half its dimensions is worse than one that never ran.
    /// </exception>
    public static WideEvent Event(this HttpContext http)
    {
        if (http.Items[ItemsKey] is WideEvent evt) return evt;

        throw new InvalidOperationException(
            $"No {nameof(WideEvent)} on this request. " +
            $"Add app.UseMiddleware<{nameof(WideEventMiddleware)}>() to the pipeline.");
    }
}
