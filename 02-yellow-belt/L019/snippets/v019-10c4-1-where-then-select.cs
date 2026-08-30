    public static IEnumerable<Contact> For(IEnumerable<Candidate> pile) =>
        pile
            .Where(candidate => candidate.Has("C#") && candidate.Has("Azure"))
            .Select(candidate => new Contact(candidate.Name, candidate.Phone));
