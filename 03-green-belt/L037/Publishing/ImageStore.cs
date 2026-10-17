namespace FacadePattern.Publishing;

/// <summary>A subsystem. Makes the three sizes every image needs.</summary>
public sealed class ImageStore(List<string> journal)
{
    public int Resize(Draft draft)
    {
        journal.Add("images");
        return draft.Images * 3;
    }
}
