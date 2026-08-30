        foreach (Candidate candidate in pile)
        {
            examined++;

            if (candidate.Has("C#") && candidate.Has("Azure"))
            {
                shortlisted.Add(candidate);
            }
        }
