static void Pass2DeepCopy()
{
    TeamSheet original = SquadData.MatchDayTemplate();
    TeamSheet copy = original.DeepCopy();

    copy.Opponent = "Brackley Town";
    copy.Formation = Formation.FourThreeThree;
    copy.Kit.Shirt = "white";
    copy.Substitutes[2] = new Player("Rennie", "FW", 21);
