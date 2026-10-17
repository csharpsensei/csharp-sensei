using FacadePattern.Publishing;

namespace FacadePattern.Callers;

/// <summary>The scheduled job, after: the same one call.</summary>
public sealed class ScheduledPublisher(ArticlePublisher publisher)
{
    public PublishResult Run(Draft draft) => publisher.Publish(draft);
}
