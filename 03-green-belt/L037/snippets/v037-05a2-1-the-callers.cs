public sealed class PublishButton(ArticlePublisher publisher)
{
    public PublishResult OnPublish(Draft draft) => publisher.Publish(draft);
}
