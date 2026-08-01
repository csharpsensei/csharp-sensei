// V007 — Async/Await From the Ground Up
// And why it isn't threading
// https://github.com/csharpsensei/csharp-sensei
//
// Runs offline. ReportApi stands in for a remote service: it awaits a timer
// rather than a network call, so the sample needs no internet and still
// demonstrates real asynchronous waiting.

namespace AsyncAwaitFromTheGroundUp;

internal static class Program
{
    static async Task Main()
    {
        ReportApi api = new ReportApi();

        // ------------------------------------------------------- PART ONE --
        // await frees the thread instead of parking it.

        Console.WriteLine("fetching report 1 ...");

        string report = await FetchReportAsync(api);

        Console.WriteLine("report length : " + report.Length);
        Console.WriteLine();

        // ------------------------------------------------------- PART TWO --
        // Async is not threading. Waiting needs no thread; thinking does.

        int before = Environment.CurrentManagedThreadId;
        Console.WriteLine("before await : thread " + before);

        await Task.Delay(500);

        int after = Environment.CurrentManagedThreadId;
        Console.WriteLine("after  await : thread " + after);
        Console.WriteLine();

        int computeThread = 0;

        int primes = await Task.Run(() =>
        {
            computeThread = Environment.CurrentManagedThreadId;
            return CountPrimes(2000000);
        });

        Console.WriteLine("delay   : thread " + before + " -> thread " + after);
        Console.WriteLine("compute : thread " + computeThread);
        Console.WriteLine("primes below 2000000 : " + primes);
        Console.WriteLine();

        // ----------------------------------------------------- PART THREE --
        // Task for no value, Task<T> for a value.

        await SaveReportAsync(report);
        Console.WriteLine("saved report to report.json");

        int count = await CountRecordsAsync(api);
        Console.WriteLine("records counted : " + count);
        Console.WriteLine();

        // ------------------------------------------------------ PART FOUR --
        // The five mistakes.
        //
        // Mistakes 1, 3 and 4 are compile-time or process-killing faults, so
        // the broken form of each lives in snippets/ (excluded from the build)
        // and only the fix runs here. Mistakes 2 and 5 run both ways.

        // 1. async void hides completion and failure. Return Task instead.
        //    The broken form is snippets/v007-17a1-1-mistake-async-void.cs.
        //    Calling an async void method that throws ends the process: there
        //    is no Task for the exception to attach to.
        await HandleAsync(report);
        Console.WriteLine("mistake 1: HandleAsync returned a Task we could await");

        // 2. .Result and .Wait block the calling thread. Legal here, but this
        //    is the line that starves a thread pool under load, and in a
        //    desktop application it can deadlock outright.
        string blocked = api.GetReportAsync(1).Result;
        Console.WriteLine("mistake 2: .Result blocked and returned " +
                          blocked.Length + " characters");

        string awaited = await api.GetReportAsync(1);
        Console.WriteLine("mistake 2: await returned the same " +
                          awaited.Length + " characters, without blocking");

        // 3. An async method with no await warns CS1998 and runs synchronously.
        //    The broken form is snippets/v007-17a3-1-mistake-no-await.cs.
        int known = await GetCountAsync();
        Console.WriteLine("mistake 3: Task.FromResult gave " + known +
                          " with no async machinery");

        // 4. Not awaiting starts the work and walks away. The broken form is
        //    snippets/v007-17a4-1-mistake-not-awaiting.cs.
        await SaveReportAsync(report);
        Console.WriteLine("mistake 4: awaited, so the file is on disk before " +
                          "the next line reads it");

        // 5. Awaiting in a loop when the calls are independent.
        int[] reportIds = [1, 2, 3, 4, 5];

        long serialStart = Environment.TickCount64;

        List<string> serial = new List<string>();

        foreach (int id in reportIds)
        {
            serial.Add(await api.GetReportAsync(id));
        }

        long serialMs = Environment.TickCount64 - serialStart;

        long togetherStart = Environment.TickCount64;

        Task<string>[] pending = reportIds
            .Select(id => api.GetReportAsync(id))
            .ToArray();

        string[] together = await Task.WhenAll(pending);

        long togetherMs = Environment.TickCount64 - togetherStart;

        Console.WriteLine("mistake 5: " + serial.Count + " reports one after " +
                          "another took " + serialMs + " ms");
        Console.WriteLine("mistake 5: " + together.Length + " reports with " +
                          "Task.WhenAll took " + togetherMs + " ms");
    }

    // ---------------------------------------------------------------------
    // Part one: the same fetch, written asynchronously.

    static async Task<string> FetchReportAsync(ReportApi api)
    {
        string report = await api.GetReportAsync(1);
        return report;
    }

    // ---------------------------------------------------------------------
    // Part three: Task for no value, Task<T> for a value.

    static async Task SaveReportAsync(string report)
    {
        await File.WriteAllTextAsync("report.json", report);
    }

    static async Task<int> CountRecordsAsync(ReportApi api)
    {
        string report = await api.GetReportAsync(1);

        return CountRecords(report);
    }

    // ---------------------------------------------------------------------
    // Part four: the fixed forms.

    static async Task HandleAsync(string report)
    {
        await SaveReportAsync(report);
    }

    static Task<int> GetCountAsync()
    {
        return Task.FromResult(5);
    }

    // ---------------------------------------------------------------------
    // Plain synchronous helpers. Neither of these waits for anything, so
    // neither of them is async.

    static int CountRecords(string report)
    {
        int count = 0;

        foreach (string line in report.Split('\n'))
        {
            if (line.StartsWith("record,"))
            {
                count++;
            }
        }

        return count;
    }

    static int CountPrimes(int limit)
    {
        bool[] composite = new bool[limit];
        int count = 0;

        for (int n = 2; n < limit; n++)
        {
            if (composite[n])
            {
                continue;
            }

            count++;

            for (long multiple = (long)n * n; multiple < limit; multiple += n)
            {
                composite[multiple] = true;
            }
        }

        return count;
    }
}

/// <summary>
/// Stands in for a remote service. The delay is a timer, not a sleep: no
/// thread is held while it runs, which is the whole point of the lesson.
/// </summary>
internal sealed class ReportApi
{
    public async Task<string> GetReportAsync(int id)
    {
        await Task.Delay(200);

        return "REPORT " + id +
               "\nrecord,1\nrecord,2\nrecord,3\nrecord,4\nrecord,5";
    }
}
