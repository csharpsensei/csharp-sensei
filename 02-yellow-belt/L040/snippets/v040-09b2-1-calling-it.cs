IEnumerable<string> pages = Pages.Written(2, trace);
trace.Add("Written(2) called, pages made so far: " + trace.Count);

foreach (string page in pages)
{
    trace.Add("reading " + page);
}
