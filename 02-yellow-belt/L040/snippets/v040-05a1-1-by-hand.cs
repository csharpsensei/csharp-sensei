var byHand = new List<string>();
using IEnumerator<string> bookmark = list.GetEnumerator();
while (bookmark.MoveNext())
{
    byHand.Add(bookmark.Current);
}
