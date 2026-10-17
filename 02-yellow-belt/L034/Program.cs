using GenericsFromScratch.Collections;
using GenericsFromScratch.Harvesting;
using GenericsFromScratch.Legacy;
using GenericsFromScratch.Reporting;

// Composition root only. Four passes, each proving one claim the lesson
// makes, in the order the lesson makes it.

Pass1CarrierBag();
Pass2TypedList();
Pass3YourOwnGeneric();
Pass4Constraints();

static void Pass1CarrierBag()
{
    var report = UntypedHarvestLog.TotalOf(SampleData.MixedBag());

    Log.Pass("Pass 1: an ArrayList of harvest weights");
    Log.Item("items packed     " + report.Packed);
    Log.Item("total reached    " + report.TotalGrams + " g");
    Log.Item("then it threw    " + report.Failure);
}

static void Pass2TypedList()
{
    List<int> weights = SampleData.Weights();
    int total = 0;
    foreach (int grams in weights)
    {
        total += grams;
    }

    Log.Pass("Pass 2: the same weights, as a typed List");
    Log.Item("items packed     " + weights.Count);
    Log.Item("total reached    " + total + " g");
}

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

static void Pass4Constraints()
{
    int heaviest = Ranking.Largest(SampleData.Weights());
    string lastCrop = Ranking.Largest(SampleData.Crops());
    Harvest biggest = Ranking.Largest(SampleData.Harvests());

    Log.Pass("Pass 4: one constrained method, three types");
    Log.Item("heaviest weight  " + heaviest + " g");
    Log.Item("last crop A to Z " + lastCrop);
    Log.Item("biggest harvest  " + biggest.Crop + ", " + biggest.Grams + " g");
}
