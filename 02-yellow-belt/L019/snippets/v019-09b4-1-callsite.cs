        List<Candidate> byQuery = Shortlist.For(CandidatePool.All).ToList();
        int withCSharp = Shortlist.WithCSharp(CandidatePool.All).Count();
        bool sameAsLoop = byQuery.SequenceEqual(byHand.Shortlisted);

        Console.WriteLine($"  With C# alone: {withCSharp}");
        Console.WriteLine($"  With C# and Azure: {byQuery.Count}");
        Console.WriteLine($"  Same four, same order: {sameAsLoop}");
