    public static IEnumerable<Candidate> For(IEnumerable<Candidate> pile) =>
        pile.Where(candidate => candidate.Has("C#") && candidate.Has("Azure"));
