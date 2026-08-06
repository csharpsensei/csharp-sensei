public class ReportBuilder
{
    private readonly IReportDestination _destination;

    public ReportBuilder(IReportDestination destination)
        => _destination = destination;

    public void Publish()
    {
        string report = Build();
        _destination.Send(report);
    }
}
