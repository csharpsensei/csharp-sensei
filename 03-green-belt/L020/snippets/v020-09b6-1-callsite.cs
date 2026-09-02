public static class SettingsScreen
{
    public static Screen Draw(IScreenTheme theme)
    {
        IHeading heading = theme.CreateHeading();
        IButton button = theme.CreateButton();
        ICaption caption = theme.CreateCaption();

        return new Screen(
            new[] { heading.Style, button.Style, caption.Style },
            new[]
            {
                heading.Draw("Display settings"),
                button.Draw("Save"),
                caption.Draw("changes apply straight away")
            });
    }
}
