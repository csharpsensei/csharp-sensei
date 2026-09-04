using System.Runtime.CompilerServices;

namespace InsideAsyncAwait.ByHand;

/// <summary>
/// What is left of the method once the body has moved onto the docket: fill
/// the docket in, start it, and hand the caller the Task the builder owns.
/// The compiler writes exactly this shape, and it is three lines.
/// </summary>
public static class AverageReadingByHand
{
    public static Task<double> ReadAverageAsync(string a, string b)
    {
        ReadAverageMachine machine = new() { A = a, B = b };
        machine.Builder = AsyncTaskMethodBuilder<double>.Create();
        machine.Builder.Start(ref machine);
        return machine.Builder.Task;
    }
}
