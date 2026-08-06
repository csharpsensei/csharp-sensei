public class ReportBuilder
{
    private readonly FileDestination _destination
        = new FileDestination("C:/reports");

    public void Publish()
    {
        string report = Build();
        _destination.Send(report);
    }
}
