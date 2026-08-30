        foreach (Contact contact in ContactSheet.For(CandidatePool.All))
        {
            Console.WriteLine($"  {contact.Name.PadRight(20)}{contact.Phone}");
        }
