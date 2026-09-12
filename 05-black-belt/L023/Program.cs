using System.Diagnostics;
using TailSampling.Checkout;
using TailSampling.Reporting;
using TailSampling.Sampling;

namespace TailSampling;

public static class Program
{
    private const int HeadOneIn = 20;

    public static void Main()
    {
        // Optional, and worth setting. It pins the trace id to the W3C format
        // on every runtime this might be run on, which is the thing a real
        // head sampler hashes.
        Activity.DefaultIdFormat = ActivityIdFormat.W3C;
        Activity.ForceDefaultIdFormat = true;

        List<Order> orders = Workload.Build();

        DecidedAtTheStart(orders);
        Report.Blank();
        List<Activity> completed = DecidedAtTheEnd(orders);
        Report.Blank();
        WithoutYourOwnAttributes(orders, completed);
    }

    /// <summary>
    /// Pass one. The sampler decides before the activity exists, so a failure
    /// that happens later cannot be reached back for.
    /// </summary>
    private static void DecidedAtTheStart(List<Order> orders)
    {
        Report.Line("Pass 1: head sampling. The decision is taken before the request runs.");

        CheckoutService checkout = new CheckoutService();

        using (HeadSampler sampler = new HeadSampler(CheckoutService.SourceName, HeadOneIn))
        {
            foreach (Order order in orders)
            {
                checkout.Run(order);
            }

            int failed = Failures(orders);
            int recorded = ErrorsIn(sampler.Recorded);

            Report.Row("checkouts run", orders.Count);
            Report.Row("of those, failed", failed);
            Report.Row("activities created", sampler.Recorded.Count);
            Report.Row("activities never created", orders.Count - sampler.Recorded.Count);
            Report.Row("failed checkouts recorded", recorded, "  of " + failed);
            Report.Line("  The other " + (failed - recorded)
                        + " were not dropped. They were never traced.");
        }
    }

    /// <summary>
    /// Pass two. Everything is recorded first and judged once it has ended,
    /// so the rules can look at what actually happened.
    /// </summary>
    private static List<Activity> DecidedAtTheEnd(List<Order> orders)
    {
        Report.Line("Pass 2: tail sampling. Every trace recorded, then judged once it ended.");

        CheckoutService checkout = new CheckoutService();
        List<Activity> completed;

        using (TraceBuffer buffer = new TraceBuffer(CheckoutService.SourceName))
        {
            foreach (Order order in orders)
            {
                checkout.Run(order);
            }

            completed = buffer.Completed;
        }

        int[] kept = Judge(completed, businessTagsVisible: true);

        PrintKept(kept, orders.Count, vipTail: "");
        Report.Row("failed checkouts recorded", kept[(int)Decision.Error],
                   "  of " + Failures(orders));
        Report.Line("  To get that from head sampling you would have to keep all "
                    + orders.Count + ".");

        return completed;
    }

    /// <summary>
    /// Pass three. The same rules against the same traces, with the three tags
    /// the framework never sets treated as absent.
    /// </summary>
    private static void WithoutYourOwnAttributes(List<Order> orders, List<Activity> completed)
    {
        Report.Line("Pass 3: the same policy, with only the framework's own attributes.");
        Report.Line("  http.route, http.response.status_code, duration. Nothing else.");

        int[] kept = Judge(completed, businessTagsVisible: false);

        PrintKept(kept, orders.Count, vipTail: "   <- matched nothing");
        Report.Line("  " + QuietVips(orders)
                    + " vip checkouts that neither failed nor ran slow are gone.");
    }

    private static int[] Judge(List<Activity> traces, bool businessTagsVisible)
    {
        TailPolicy policy = new TailPolicy(businessTagsVisible);
        int[] kept = new int[5];

        foreach (Activity trace in traces)
        {
            kept[(int)policy.Judge(trace)]++;
        }

        return kept;
    }

    private static void PrintKept(int[] kept, int total, string vipTail)
    {
        Report.Row("kept, the trace failed", kept[(int)Decision.Error]);
        Report.Row("kept, the trace was slow", kept[(int)Decision.Slow]);
        Report.Row("kept, the customer is vip", kept[(int)Decision.Vip], vipTail);
        Report.Row("kept, baseline 1 in 20", kept[(int)Decision.Baseline]);
        Report.Row("kept in total", Total(kept), "  of " + total);
    }

    private static int Total(int[] kept)
    {
        return kept[(int)Decision.Error] + kept[(int)Decision.Slow]
             + kept[(int)Decision.Vip] + kept[(int)Decision.Baseline];
    }

    private static int Failures(List<Order> orders)
    {
        int n = 0;

        foreach (Order order in orders)
        {
            if (order.Failed)
            {
                n++;
            }
        }

        return n;
    }

    private static int QuietVips(List<Order> orders)
    {
        int n = 0;

        foreach (Order order in orders)
        {
            if (order.Tier == "vip" && !order.Failed && !order.Slow)
            {
                n++;
            }
        }

        return n;
    }

    private static int ErrorsIn(List<Activity> traces)
    {
        int n = 0;

        foreach (Activity trace in traces)
        {
            if (trace.Status == ActivityStatusCode.Error)
            {
                n++;
            }
        }

        return n;
    }
}
