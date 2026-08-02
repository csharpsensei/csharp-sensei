public void CopyToActivity()
{
    var activity = Activity.Current;
    if (activity is null) return;

    foreach (var (key, value) in _fields)
        activity.SetTag(key, value);
}
