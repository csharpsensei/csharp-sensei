using FacadePattern.Publishing;

namespace FacadePattern.Callers;

/// <summary>The button handler, after: one call, no knowledge of the steps.</summary>
public sealed class PublishButton(ArticlePublisher publisher)
{
    public PublishResult OnPublish(Draft draft) => publisher.Publish(draft);
}
