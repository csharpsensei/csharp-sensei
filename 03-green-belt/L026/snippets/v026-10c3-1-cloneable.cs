    LegacySheet sheet = new LegacySheet("Hartley Rovers", MatchNotes());
    LegacyRota rota = new LegacyRota("Hartley Rovers", MatchNotes());

    LegacySheet sheetCopy = (LegacySheet)sheet.Clone();
    LegacyRota rotaCopy = (LegacyRota)rota.Clone();

    sheetCopy.Notes.Add("referee change");
    rotaCopy.Notes.Add("referee change");
