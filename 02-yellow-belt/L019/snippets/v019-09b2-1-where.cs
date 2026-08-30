    public static IEnumerable<Candidate> WithCSharp(IEnumerable<Candidate> pile) =>
        pile.Where(candidate => candidate.Has("C#"));
