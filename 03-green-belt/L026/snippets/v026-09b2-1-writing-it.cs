    public TeamSheet DeepCopy()
    {
        return new TeamSheet(
            Opponent,
            Formation,
            new KitChoice(Kit.Shirt, Kit.Shorts, Kit.Socks),
            new List<Player>(Starters),
            new List<Player>(Substitutes));
    }
