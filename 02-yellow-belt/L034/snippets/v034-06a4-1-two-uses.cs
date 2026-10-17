static void Pass3YourOwnGeneric()
{
    var weights = new RecentItems<int>(capacity: 3);
    foreach (int grams in SampleData.Weights()) weights.Add(grams);

    var crops = new RecentItems<string>(capacity: 2);
    foreach (string crop in SampleData.Crops()) crops.Add(crop);

    Log.Pass("Pass 3: written once, used with two type arguments");
    Log.Item("weights kept     " + Describe.List(weights.Items));
    Log.Item("crops kept       " + Describe.List(crops.Items));
}
