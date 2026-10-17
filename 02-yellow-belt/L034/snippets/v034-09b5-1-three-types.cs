static void Pass4Constraints()
{
    int heaviest = Ranking.Largest(SampleData.Weights());
    string lastCrop = Ranking.Largest(SampleData.Crops());
    Harvest biggest = Ranking.Largest(SampleData.Harvests());
