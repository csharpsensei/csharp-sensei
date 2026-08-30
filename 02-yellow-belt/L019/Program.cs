using LinqBasics.Data;
using LinqBasics.Legacy;
using LinqBasics.Model;
using LinqBasics.Sifting;

namespace LinqBasics;

/// <summary>
/// Composition root. Three passes over the same twelve applications: the loop,
/// the same answer written as a query, and the query that also changes the
/// shape of what comes back.
/// </summary>
public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Pass 1: the shortlist, written as a loop");
        SiftResult byHand = HandRolledSift.Run(CandidatePool.All);
        Console.WriteLine($"  Examined: {byHand.Examined}");
        Console.WriteLine($"  Kept: {byHand.Shortlisted.Count}");
        foreach (Candidate candidate in byHand.Shortlisted)
        {
            Console.WriteLine($"  {candidate.Name}");
        }

        Console.WriteLine();

        Console.WriteLine("Pass 2: the same shortlist, written as a query");
        List<Candidate> byQuery = Shortlist.For(CandidatePool.All).ToList();
        int withCSharp = Shortlist.WithCSharp(CandidatePool.All).Count();
        bool sameAsLoop = byQuery.SequenceEqual(byHand.Shortlisted);

        Console.WriteLine($"  With C# alone: {withCSharp}");
        Console.WriteLine($"  With C# and Azure: {byQuery.Count}");
        Console.WriteLine($"  Same four, same order: {sameAsLoop}");
        foreach (Candidate candidate in byQuery)
        {
            Console.WriteLine($"  {candidate.Name}");
        }

        Console.WriteLine();

        Console.WriteLine("Pass 3: the contact sheet, Where then Select");
        int wholePile = ContactSheet.All(CandidatePool.All).Count();
        int sifted = ContactSheet.For(CandidatePool.All).Count();

        Console.WriteLine($"  Select on the whole pile: {wholePile}");
        Console.WriteLine($"  Where then Select: {sifted}");
        foreach (Contact contact in ContactSheet.For(CandidatePool.All))
        {
            Console.WriteLine($"  {contact.Name.PadRight(20)}{contact.Phone}");
        }
    }
}
