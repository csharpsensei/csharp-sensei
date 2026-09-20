    List<string> unavailable = new List<string> { "Ferris", "Nkemdi" };

    SquadNote note = new SquadNote(
        "Hartley Rovers", Formation.FourFourTwo, unavailable);

    SquadNote changed = note with
    {
        Opponent = "Brackley Town",
        Formation = Formation.FourThreeThree
    };

    changed.Unavailable.Add("Lomax");
