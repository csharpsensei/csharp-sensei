    public static SiftResult Run(IReadOnlyList<Candidate> pile)
    {
        List<Candidate> shortlisted = [];
        int examined = 0;

        foreach (Candidate candidate in pile)
        {
            examined++;

            if (candidate.Has("C#") && candidate.Has("Azure"))
            {
                shortlisted.Add(candidate);
            }
        }

        return new SiftResult(examined, shortlisted);
    }
