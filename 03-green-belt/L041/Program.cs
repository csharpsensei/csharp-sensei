using CompositePattern.Legacy;
using CompositePattern.Packing;
using CompositePattern.Reporting;
using CompositePattern.Seeding;

// Composition root only. Four passes, each proving one claim the lesson
// makes, in the order the lesson makes it.

Pass1TypeChecks();
Pass2OneQuestion();
Pass3TheTree();
Pass4Deeper();

static void Pass1TypeChecks()
{
    Box hamper = Hampers.Christmas();

    Log.Pass("Pass 1: a calculator that checks types, one level deep");
    Log.Item("calculator says  " + ShippingCalculator.Weigh(hamper) + " g");
    Log.Item("real weight      " + hamper.Grams() + " g");
}

static void Pass2OneQuestion()
{
    Box hamper = Hampers.Christmas();
    IPackable cheese = new Item("Cheese", 500);

    Log.Pass("Pass 2: one question, asked of a box and of an item");
    Log.Item("the hamper       " + hamper.Grams() + " g");
    Log.Item("the cheese       " + cheese.Grams() + " g");
}

static void Pass3TheTree()
{
    Log.Pass("Pass 3: walking the whole tree");
    foreach (string line in Tree.Describe(Hampers.Christmas()))
    {
        Log.Item(line);
    }
}

static void Pass4Deeper()
{
    Box hamper = Hampers.Christmas();
    Box tin = new Box("Sample tin", packagingGrams: 50);
    tin.Add(new Item("Mints", 30));
    Hampers.ChocolateBoxIn(hamper).Add(tin);

    Log.Pass("Pass 4: a tin added three levels down, no code changed");
    Log.Item("the hamper       " + hamper.Grams() + " g");
    Log.Item("calculator says  " + ShippingCalculator.Weigh(hamper) + " g");
}
