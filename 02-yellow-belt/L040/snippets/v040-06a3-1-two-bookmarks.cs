using IEnumerator<string> first = list.GetEnumerator();
using IEnumerator<string> second = list.GetEnumerator();

first.MoveNext();
first.MoveNext();
first.MoveNext();
second.MoveNext();
