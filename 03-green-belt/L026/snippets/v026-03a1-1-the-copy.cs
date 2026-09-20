static void Pass1ShallowCopy()
{
    TeamSheet original = SquadData.MatchDayTemplate();
    TeamSheet copy = original.ShallowCopy();

    copy.Opponent = "Brackley Town";
    copy.Formation = Formation.FourThreeThree;
    copy.Kit.Shirt = "white";
    copy.Substitutes[2] = new Player("Rennie", "FW", 21);
