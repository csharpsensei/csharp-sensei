    public static IEnumerable<Contact> All(IEnumerable<Candidate> pile) =>
        pile.Select(candidate => new Contact(candidate.Name, candidate.Phone));
