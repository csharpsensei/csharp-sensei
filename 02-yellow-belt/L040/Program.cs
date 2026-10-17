using HowIterationWorks.Reading;
using HowIterationWorks.Reporting;
using HowIterationWorks.Sequences;

// Composition root only. Four passes, each proving one claim the lesson
// makes, in the order the lesson makes it.

Pass1LoopAndByHand();
Pass2TwoBookmarks();
Pass3Yield();
Pass4Endless();

static void Pass1LoopAndByHand()
{
    var list = new ReadingList(new[] { "Dune", "Emma", "Ulysses" });

    var withLoop = new List<string>();
    foreach (string title in list) withLoop.Add(title);

    var byHand = new List<string>();
    using IEnumerator<string> bookmark = list.GetEnumerator();
    while (bookmark.MoveNext())
    {
        byHand.Add(bookmark.Current);
    }

    Log.Pass("Pass 1: the loop, and the same walk by hand");
    Log.Item("with the loop   " + string.Join(", ", withLoop));
    Log.Item("by hand         " + string.Join(", ", byHand));
}

static void Pass2TwoBookmarks()
{
    var list = new ReadingList(new[] { "Dune", "Emma", "Ulysses" });
    using IEnumerator<string> first = list.GetEnumerator();
    using IEnumerator<string> second = list.GetEnumerator();

    first.MoveNext();
    first.MoveNext();
    first.MoveNext();
    second.MoveNext();

    Log.Pass("Pass 2: two bookmarks, one book");
    Log.Item("bookmark one    at " + first.Current);
    Log.Item("bookmark two    at " + second.Current);
}

static void Pass3Yield()
{
    var trace = new List<string>();
    IEnumerable<string> pages = Pages.Written(2, trace);
    trace.Add("Written(2) called, pages made so far: " + trace.Count);

    foreach (string page in pages)
    {
        trace.Add("reading " + page);
    }

    Log.Pass("Pass 3: a yield method, and when its code really runs");
    foreach (string line in trace) Log.Item(line);
}

static void Pass4Endless()
{
    IEnumerable<int> counting = Counting.From(1);

    Log.Pass("Pass 4: an endless sequence, and only what was asked");
    Log.Item("first three     " + string.Join(", ", counting.Take(3)));
}
