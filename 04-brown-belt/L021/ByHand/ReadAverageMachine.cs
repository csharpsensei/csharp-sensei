using System.Runtime.CompilerServices;
using InsideAsyncAwait.Reporting;
using InsideAsyncAwait.Stations;

namespace InsideAsyncAwait.ByHand;

/// <summary>
/// The docket, written out by hand. This is the same method as
/// <c>AverageReading.ReadAverageAsync</c> with the <c>async</c> keyword taken
/// away and the work the compiler does written into a file you can read.
/// <para>
/// State numbers follow the convention the compiler uses: <c>-1</c> means not
/// started, <c>0</c> and upward name a place to resume, and <c>-2</c> means
/// finished.
/// </para>
/// </summary>
public sealed class ReadAverageMachine : IAsyncStateMachine
{
    /// <summary>The table number. The only thing that says which piece runs next.</summary>
    public int State = -1;

    /// <summary>Owns the Task the caller is holding, and finishes it.</summary>
    public AsyncTaskMethodBuilder<double> Builder;

    /// <summary>The parameters, copied onto the docket.</summary>
    public string A = "";
    public string B = "";

    /// <summary>The one local that has to survive a wait.</summary>
    public double First;

    /// <summary>What we are waiting on right now.</summary>
    private TaskAwaiter<double> _awaiter;

    public void MoveNext()
    {
        Log.Line("  [by hand] MoveNext, state " + State + ", on " + Log.Where);

        try
        {
            switch (State)
            {
                case -1:
                    Log.Line("            nothing read yet. Ask for the first, write 0, park");
                    _awaiter = Station.ReadAsync(A).GetAwaiter();
                    State = 0;
                    Park();
                    return;

                case 0:
                    Log.Line("            first reading is on the docket. Ask for the second, write 1, park");
                    First = _awaiter.GetResult();
                    _awaiter = Station.ReadAsync(B).GetAwaiter();
                    State = 1;
                    Park();
                    return;

                case 1:
                    Log.Line("            both readings in. Write -2 and hand the answer back");
                    double second = _awaiter.GetResult();
                    State = -2;
                    Builder.SetResult((First + second) / 2);
                    return;
            }
        }
        catch (Exception failure)
        {
            State = -2;
            Builder.SetException(failure);
        }
    }

    /// <summary>
    /// Hand the docket to the builder and go and do something else. When the
    /// reading is ready, whatever thread is free calls MoveNext again.
    /// </summary>
    private void Park()
    {
        ReadAverageMachine self = this;
        Builder.AwaitOnCompleted(ref _awaiter, ref self);
    }

    /// <summary>
    /// Only does work when the machine is a struct that has to be boxed on its
    /// first park. This one is a class, so there is nothing to copy.
    /// </summary>
    public void SetStateMachine(IAsyncStateMachine stateMachine)
    {
    }
}
