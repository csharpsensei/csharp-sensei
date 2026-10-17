public sealed class ArticlePublisher(Subsystems parts)
{
    public PublishResult Publish(Draft draft)
    {
        int issues = parts.Proofreader.Check(draft);
        if (issues > 0)
            return new PublishResult(
                false, $"refused, {issues} spelling issues");

        parts.Images.Resize(draft);
        parts.Index.Add(draft.Slug);
        parts.Newsletter.Queue(draft.Slug);
        return new PublishResult(true, "published " + draft.Slug);
    }
