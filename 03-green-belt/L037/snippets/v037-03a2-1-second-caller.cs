public void Run(Draft draft)
{
    if (parts.Proofreader.Check(draft) > 0)
        return;

    parts.Images.Resize(draft);
    parts.Index.Add(draft.Slug);
}
