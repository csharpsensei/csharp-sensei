using FacadePattern.Publishing;

namespace FacadePattern.Legacy;

/// <summary>
/// DO NOT COPY THIS SHAPE. A button handler that knows every subsystem and
/// the order they must run in. Correct today; the hook of the lesson.
/// </summary>
public sealed class PublishButtonHandler(Subsystems parts)
{
    public void OnPublish(Draft draft)
    {
        if (parts.Proofreader.Check(draft) > 0)
            return;

        parts.Images.Resize(draft);
        parts.Index.Add(draft.Slug);
        parts.Newsletter.Queue(draft.Slug);
    }
}
