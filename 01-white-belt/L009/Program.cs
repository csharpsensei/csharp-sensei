using HowInheritanceWorks.Abstractions;
using HowInheritanceWorks.Drills;
using HowInheritanceWorks.Duplication;
using HowInheritanceWorks.Traps;
using NV = HowInheritanceWorks.NonVirtual;

// ---------------------------------------------------------------------------
// L009 — How Inheritance Really Works
//
// A console app, deliberately. PRODUCTION-SYSTEM.md §16.4 asks packages to ship
// a .http file instead of commented-out curl; that rule is about projects which
// serve requests. This one has none. A White Belt lesson on `virtual` should
// not need ASP.NET Core to run, so the equivalent is here: numbered demos, one
// per beat of the video, each runnable on its own.
//
//     dotnet run              lists them
//     dotnet run -- 5         runs demo 5
//     dotnet run -- all       runs all of them, in order
// ---------------------------------------------------------------------------

// Em dashes and the belt characters come out as mojibake on a console still
// running a legacy code page, which is most Windows terminals.
Console.OutputEncoding = System.Text.Encoding.UTF8;

var demos = new (int N, string Title, Action Run)[]
{
    (1, "The bad smell: two classes, one bug fixed once", Demo01Duplication),
    (2, "The fix: a base class and a colon", Demo02Inheritance),
    (3, "Constructors are not inherited — base(...) and the order", Demo03Construction),
    (4, "Every class already inherits from object", Demo04Object),
    (5, "The problem virtual solves", Demo05WithoutVirtual),
    (6, "virtual and override", Demo06Virtual),
    (7, "The trap: new instead of override", Demo07Hiding),
    (8, "abstract, and sealed override", Demo08AbstractSealed),
    (9, "The classic bug: a virtual call in a constructor", Demo09ConstructorTrap),
    (10, "The payoff: one list, one loop, four behaviours", Demo10Polymorphism),
};

var pick = args.Length > 0 ? args[0].Trim().ToLowerInvariant() : "";

if (pick is "" or "list" or "-h" or "--help")
{
    Console.WriteLine("L009 — How Inheritance Really Works\n");
    foreach (var (n, title, _) in demos)
        Console.WriteLine($"  {n,2}  {title}");
    Console.WriteLine("\n  dotnet run -- 5        one demo");
    Console.WriteLine("  dotnet run -- all      all of them");
    return 0;
}

if (pick == "all")
{
    foreach (var (n, title, run) in demos)
    {
        Header(n, title);
        run();
        Console.WriteLine();
    }
    return 0;
}

if (!int.TryParse(pick, out var wanted) || demos.All(d => d.N != wanted))
{
    Console.Error.WriteLine($"No demo '{pick}'. Run with no arguments to list them.");
    return 1;
}

var demo = demos.First(d => d.N == wanted);
Header(demo.N, demo.Title);
demo.Run();
return 0;


static void Header(int n, string title)
{
    Console.WriteLine();
    Console.WriteLine($"== {n}. {title} ".PadRight(70, '='));
    Console.WriteLine();
}


// ---------------------------------------------------------------------------
// 1 — the bad smell
// ---------------------------------------------------------------------------
static void Demo01Duplication()
{
    var forms = new FormsSessionCopyPaste("Kata", 45, attendees: 1);
    var sparring = new SparringSessionCopyPaste("Randori", 45, attendees: 1);

    Console.WriteLine("Two sessions. One attendee each. Same rule, supposedly.");
    Console.WriteLine($"  forms    ShouldCancel() -> {forms.ShouldCancel()}");
    Console.WriteLine($"  sparring ShouldCancel() -> {sparring.ShouldCancel()}");
    Console.WriteLine();
    Console.WriteLine("The rule was fixed in one class and not the other.");
    Console.WriteLine("Nothing failed. Nothing warned. No test noticed.");
}


// ---------------------------------------------------------------------------
// 2 — the fix
// ---------------------------------------------------------------------------
static void Demo02Inheritance()
{
    var drill = new FormsDrill("Kata", 45, formCount: 3);

    Console.WriteLine("FormsDrill declares one field and one constructor.");
    Console.WriteLine("Name and Minutes came from Drill and are not repeated.");
    Console.WriteLine();
    Console.WriteLine($"  Name     -> {drill.Name}");
    Console.WriteLine($"  Describe -> {drill.Describe()}");
    Console.WriteLine($"  Calories -> {drill.CaloriesBurned()}");
}


// ---------------------------------------------------------------------------
// 3 — construction order
// ---------------------------------------------------------------------------
static void Demo03Construction()
{
    Console.WriteLine("Watch which constructor finishes first.");
    Console.WriteLine();
    var drill = new SparringDrill("Randori", 30, rounds: 6);
    Console.WriteLine("  base ran first, so Name was set first:");
    Console.WriteLine($"      {drill.Name}");
    Console.WriteLine("  then the derived body set its own field:");
    Console.WriteLine($"      {drill.Describe()}");
}


// ---------------------------------------------------------------------------
// 4 — object
// ---------------------------------------------------------------------------
static void Demo04Object()
{
    var plain = new object();
    var drill = new FormsDrill("Kata", 45, formCount: 3);

    Console.WriteLine("Every class inherits from object, whether you say so or not.");
    Console.WriteLine();
    Console.WriteLine($"  new object().ToString()  -> {plain}");
    Console.WriteLine($"  drill.ToString()         -> {drill}");
    Console.WriteLine();
    Console.WriteLine("The second one is readable because Drill overrode ToString().");
    Console.WriteLine("Without that override it would print the type name too.");
    Console.WriteLine($"  drill.GetType().Name     -> {drill.GetType().Name}");
    Console.WriteLine($"  drill is object          -> {drill is object}");
}


// ---------------------------------------------------------------------------
// 5 — the problem
// ---------------------------------------------------------------------------
static void Demo05WithoutVirtual()
{
    Console.WriteLine("A method that is NOT virtual, called through a base reference,");
    Console.WriteLine("runs the base version — the object's real type is ignored.");
    Console.WriteLine();
    // The NonVirtual pair, so this really is a non-virtual method rather than
    // a hidden one. Using HidingDrill here would give the same output for a
    // different reason, and spoil demo 7.
    NV.Drill asBase = new NV.FormsDrill("Kata", 45, formCount: 3);
    Console.WriteLine($"  Drill reference -> {asBase.Describe()}");
    Console.WriteLine("  ^ that is Drill.Describe(), on a FormsDrill object.");
}


// ---------------------------------------------------------------------------
// 6 — virtual and override
// ---------------------------------------------------------------------------
static void Demo06Virtual()
{
    Drill asBase = new SparringDrill("Randori", 30, rounds: 6);

    Console.WriteLine("Same call, on a virtual method that the subclass overrode.");
    Console.WriteLine();
    Console.WriteLine($"  variable type -> Drill");
    Console.WriteLine($"  object type   -> {asBase.GetType().Name}");
    Console.WriteLine($"  Describe()    -> {asBase.Describe()}");
    Console.WriteLine();
    Console.WriteLine("The object won. That is dynamic dispatch, and it is the");
    Console.WriteLine("whole difference between virtual and not.");
    Console.WriteLine();
    Console.WriteLine("Note the override called base.Describe() and added to it,");
    Console.WriteLine("rather than throwing the base answer away.");
}


// ---------------------------------------------------------------------------
// 7 — the trap
// ---------------------------------------------------------------------------
static void Demo07Hiding()
{
    var hiding = new HidingDrill("Kata", 45, formCount: 3);
    Drill asBase = hiding;                      // the SAME object

    Console.WriteLine("One object. Two variables. Two different answers.");
    Console.WriteLine();
    Console.WriteLine($"  HidingDrill reference -> {hiding.Describe()}");
    Console.WriteLine($"  Drill       reference -> {asBase.Describe()}");
    Console.WriteLine($"  same object?          -> {ReferenceEquals(hiding, asBase)}");
    Console.WriteLine();
    Console.WriteLine("`new` hides rather than overrides, so the VARIABLE decides.");
    Console.WriteLine("Compare with demo 6, where the OBJECT decided.");
}


// ---------------------------------------------------------------------------
// 8 — abstract and sealed
// ---------------------------------------------------------------------------
static void Demo08AbstractSealed()
{
    Exercise[] exercises = [new PushUps(3), new Squats(4)];

    Console.WriteLine("abstract = virtual with the body taken away. No default,");
    Console.WriteLine("and the compiler makes every subclass supply one.");
    Console.WriteLine();
    foreach (var e in exercises)
        Console.WriteLine($"  {e.Summary()}");
    Console.WriteLine();
    Console.WriteLine("  new Exercise(\"anything\")  ->  will not compile.");
    Console.WriteLine("  There is no such thing as an exercise in general.");
    Console.WriteLine();

    var test = new BeltTestDrill("Grading", 40, rounds: 8, belt: "green");
    Console.WriteLine($"  sealed override -> {test.Describe()}");
    Console.WriteLine("  Three levels deep, and the last one. Nothing below");
    Console.WriteLine("  BeltTestDrill may replace Describe() again.");
}


// ---------------------------------------------------------------------------
// 9 — the constructor trap
// ---------------------------------------------------------------------------
static void Demo09ConstructorTrap()
{
    var broken = new BrokenSummaryDrill("Randori", 30, rounds: 6);

    Console.WriteLine("The base constructor called a virtual method.");
    Console.WriteLine("Dispatch sent it to the override, which read a field the");
    Console.WriteLine("derived constructor had not assigned yet.");
    Console.WriteLine();
    Console.WriteLine($"  CachedSummary (built during construction) -> {broken.CachedSummary}");
    Console.WriteLine($"  Describe()    (called afterwards)         -> {broken.Describe()}");
    Console.WriteLine();
    Console.WriteLine("Same method. Same object. The only difference is when it ran.");
}


// ---------------------------------------------------------------------------
// 10 — the payoff
// ---------------------------------------------------------------------------
static void Demo10Polymorphism()
{
    List<Drill> session =
    [
        new FormsDrill("Kata", 45, formCount: 3),
        new SparringDrill("Randori", 30, rounds: 6),
        new ConditioningDrill("Circuits", 20, weighted: true),
        new BeltTestDrill("Grading", 40, rounds: 8, belt: "green"),
    ];

    var total = 0;
    foreach (var drill in session)                  // one loop
    {
        Console.WriteLine($"  {drill.Describe()}");
        Console.WriteLine($"      {drill.CaloriesBurned()} calories");
        total += drill.CaloriesBurned();
    }

    Console.WriteLine();
    Console.WriteLine($"  total -> {total} calories");
    Console.WriteLine();
    Console.WriteLine("Four types. One List<Drill>. One loop. No switch, no if,");
    Console.WriteLine("no type check — and adding a fifth drill changes none of it.");
}
