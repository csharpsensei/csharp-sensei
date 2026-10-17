using FacadePattern.Publishing;

namespace FacadePattern.Legacy;

/// <summary>
/// DO NOT COPY THIS SHAPE. A second caller that copied the steps and
/// missed one. Nothing fails; the subscribers simply never hear about it.
/// </summary>
public sealed class ScheduledPublisherByHand(Subsystems parts)
{
    public void Run(Draft draft)
    {
        if (parts.Proofreader.Check(draft) > 0)
            return;

        parts.Images.Resize(draft);
        parts.Index.Add(draft.Slug);
    }
}
