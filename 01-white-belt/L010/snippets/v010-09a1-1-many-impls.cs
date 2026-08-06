var destinations = new List<IReportDestination>
{
    new FileDestination("reports"),
    new ConsoleDestination(),
    new NullDestination()
};
