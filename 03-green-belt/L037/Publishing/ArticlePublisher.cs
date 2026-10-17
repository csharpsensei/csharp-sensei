namespace FacadePattern.Publishing;

/// <summary>
/// The facade. One method that knows the steps and their order. It adds no
/// rules of its own that a subsystem should own, and it does not hide the
/// subsystems: anything that needs one directly can still have it.
/// </summary>
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
}
