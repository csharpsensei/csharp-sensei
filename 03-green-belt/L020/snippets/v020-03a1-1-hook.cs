public static class HandBuiltScreen
{
    public static Screen Draw(string mode)
    {
        IHeading heading = mode == "high-contrast"
            ? new HighContrastHeading()
            : new LightHeading();

        IButton button = new LightButton();

        ICaption caption = mode == "high-contrast"
            ? new HighContrastCaption()
            : new LightCaption();
