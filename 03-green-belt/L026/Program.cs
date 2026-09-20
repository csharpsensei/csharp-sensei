using PrototypePattern.Legacy;
using PrototypePattern.Models;
using PrototypePattern.Modern;
using PrototypePattern.Reporting;
using PrototypePattern.Seeding;
using PrototypePattern.Sheets;

// Composition root only. Four passes, each proving one claim the lesson
// makes, in the order the lesson makes it.

Pass1ShallowCopy();
Pass2DeepCopy();
Pass3WithExpression();
Pass4Cloneable();

static void Pass1ShallowCopy()
{
    TeamSheet original = SquadData.MatchDayTemplate();
    TeamSheet copy = original.ShallowCopy();

    copy.Opponent = "Brackley Town";
    copy.Formation = Formation.FourThreeThree;
    copy.Kit.Shirt = "white";
    copy.Substitutes[2] = new Player("Rennie", "FW", 21);

    Log.Pass("Pass 1: a shallow copy, then four changes made to the copy");
    Log.Item("copy      " + Describe.Line(copy));
    Log.Item("original  " + Describe.Line(original));
    Log.Item("opponent and formation moved on the copy alone");
    Log.Item("kit and substitutes moved on both");
}

static void Pass2DeepCopy()
{
    TeamSheet original = SquadData.MatchDayTemplate();
    TeamSheet copy = original.DeepCopy();

    copy.Opponent = "Brackley Town";
    copy.Formation = Formation.FourThreeThree;
    copy.Kit.Shirt = "white";
    copy.Substitutes[2] = new Player("Rennie", "FW", 21);

    bool sameList = ReferenceEquals(
        copy.Substitutes, original.Substitutes);
    bool sameKit = ReferenceEquals(copy.Kit, original.Kit);
    bool samePlayer = ReferenceEquals(
        copy.Substitutes[1], original.Substitutes[1]);

    Log.Pass("Pass 2: the same four changes, through a deep copy");
    Log.Item("copy      " + Describe.Line(copy));
    Log.Item("original  " + Describe.Line(original));
    Log.Item("shares the substitutes list  " + Describe.YesNo(sameList));
    Log.Item("shares the kit object        " + Describe.YesNo(sameKit));
    Log.Item("shares the player at slot 1  " + Describe.YesNo(samePlayer));
}

static void Pass3WithExpression()
{
    List<string> unavailable = new List<string> { "Ferris", "Nkemdi" };

    SquadNote note = new SquadNote(
        "Hartley Rovers", Formation.FourFourTwo, unavailable);

    SquadNote changed = note with
    {
        Opponent = "Brackley Town",
        Formation = Formation.FourThreeThree
    };

    changed.Unavailable.Add("Lomax");

    bool sameList = ReferenceEquals(changed.Unavailable, note.Unavailable);

    Log.Pass("Pass 3: a with expression on a record");
    Log.Item("copy      " + Describe.Note(changed));
    Log.Item("original  " + Describe.Note(note));
    Log.Item("shares the unavailable list  " + Describe.YesNo(sameList));
}

static List<string> MatchNotes()
{
    return new List<string> { "kit clash", "coach at 1pm" };
}

static void Pass4Cloneable()
{
    LegacySheet sheet = new LegacySheet("Hartley Rovers", MatchNotes());
    LegacyRota rota = new LegacyRota("Hartley Rovers", MatchNotes());

    LegacySheet sheetCopy = (LegacySheet)sheet.Clone();
    LegacyRota rotaCopy = (LegacyRota)rota.Clone();

    sheetCopy.Notes.Add("referee change");
    rotaCopy.Notes.Add("referee change");

    Log.Pass("Pass 4: two types, both ICloneable, the same call on each");
    Log.Item("LegacySheet  notes on the original after editing "
        + "the clone  " + sheet.Notes.Count);
    Log.Item("LegacyRota   notes on the original after editing "
        + "the clone  " + rota.Notes.Count);
    Log.Item("one Clone is shallow and one is deep. "
        + "the type tells you nothing");
}
