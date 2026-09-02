        IHeading heading = mode == "high-contrast"
            ? new HighContrastHeading()
            : new LightHeading();

        IButton button = new LightButton();

        ICaption caption = mode == "high-contrast"
            ? new HighContrastCaption()
            : new LightCaption();
