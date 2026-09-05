using SingletonPattern.Billing;
using SingletonPattern.Injected;
using SingletonPattern.Naive;
using SingletonPattern.Reporting;
using SingletonPattern.Safe;

namespace SingletonPattern;

public static class Program
{
    private const int Racers = 4;

    public static void Main()
    {
        TheDependencyYouCannotSee();
        Log.Blank();
        FourThreadsAtOnce();
        Log.Blank();
        TheSameJobDeclared();
    }

    /// <summary>
    /// Pass one. The service constructor takes nothing, so its signature says
    /// it has no dependencies. It has one, and the state behind it outlives
    /// every instance of the service.
    /// </summary>
    private static void TheDependencyYouCannotSee()
    {
        Log.Line("Pass 1: the dependency you cannot see");
        Log.Line("  InvoiceService's constructor takes nothing at all.");

        InvoiceService first = new InvoiceService();
        Log.Line("  first service object:");
        Log.Line("    " + first.Issue("Acme Tools"));
        Log.Line("    " + first.Issue("Bruno Cafe"));

        InvoiceService second = new InvoiceService();
        Log.Line("  a brand new service object:");
        Log.Line("    " + second.Issue("Cascade Ltd"));
        Log.Line("    " + second.Issue("Delta Foods"));

        Log.Line("  the service was new. the numbering was not.");
    }

    /// <summary>
    /// Pass two. Four threads reach for the same lazily created instance at
    /// the same moment, first through the naive null check and then through a
    /// static field initialiser.
    /// </summary>
    private static void FourThreadsAtOnce()
    {
        Log.Line("Pass 2: four threads reach for it at the same moment");

        object[] naive = AllAtOnce(() => RateTable.Instance);
        Log.Line("  constructors that ran:    " + RateTable.Constructions);
        Log.Line("  distinct objects handed back: " + Distinct(naive));

        Log.Line("  with a static readonly field instead:");
        object[] safe = AllAtOnce(() => RateTableOnce.Instance);
        Log.Line("  constructors that ran:    " + RateTableOnce.Constructions);
        Log.Line("  distinct objects handed back: " + Distinct(safe));
    }

    /// <summary>
    /// Pass three. The same work, with the number source named in the
    /// constructor, so the call site decides how many exist.
    /// </summary>
    private static void TheSameJobDeclared()
    {
        Log.Line("Pass 3: the same job, with the dependency declared");
        Log.Line("  BillingService's constructor asks for a number source.");

        IInvoiceNumbers shared = new CountingInvoiceNumbers();
        BillingService one = new BillingService(shared);
        BillingService two = new BillingService(shared);
        Log.Line("  two services sharing one source:");
        Log.Line("    " + one.Issue("Acme Tools"));
        Log.Line("    " + two.Issue("Bruno Cafe"));

        BillingService three = new BillingService(new CountingInvoiceNumbers());
        BillingService four = new BillingService(new CountingInvoiceNumbers());
        Log.Line("  two services with one source each:");
        Log.Line("    " + three.Issue("Cascade Ltd"));
        Log.Line("    " + four.Issue("Delta Foods"));

        IInvoiceNumbers fake = new FixedInvoiceNumbers("INV-9000");
        BillingService underTest = new BillingService(fake);
        Log.Line("  a test, handed a fake source:");
        Log.Line("    " + underTest.Issue("Test customer"));

        Log.Line("  the call site chose. the class did not.");
    }

    /// <summary>
    /// Starts four real threads, holds them at a gate until every one of them
    /// has arrived, then releases them together. Dedicated threads rather
    /// than pool work, so the four are genuinely running before the gate opens.
    /// </summary>
    private static object[] AllAtOnce(Func<object> ask)
    {
        object[] got = new object[Racers];
        Thread[] runners = new Thread[Racers];

        using ManualResetEventSlim gate = new ManualResetEventSlim(false);

        for (int i = 0; i < Racers; i++)
        {
            int slot = i;
            runners[slot] = new Thread(() =>
            {
                gate.Wait();
                got[slot] = ask();
            });
            runners[slot].Start();
        }

        Thread.Sleep(100);
        gate.Set();

        foreach (Thread runner in runners)
        {
            runner.Join();
        }

        return got;
    }

    private static int Distinct(object[] items)
    {
        HashSet<object> seen = new(ReferenceEqualityComparer.Instance);

        foreach (object item in items)
        {
            seen.Add(item);
        }

        return seen.Count;
    }
}
