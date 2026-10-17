namespace FacadePattern.Publishing;

/// <summary>The four subsystems, built together so a pass can hand them out.</summary>
public sealed record Subsystems(
    Proofreader Proofreader, ImageStore Images,
    SearchIndex Index, Newsletter Newsletter)
{
    public static Subsystems Build(List<string> journal) =>
        new Subsystems(new Proofreader(journal), new ImageStore(journal),
            new SearchIndex(journal), new Newsletter(journal));
}
