static void Pass2TypedList()
{
    List<int> weights = SampleData.Weights();
    int total = 0;
    foreach (int grams in weights)
    {
        total += grams;
    }
