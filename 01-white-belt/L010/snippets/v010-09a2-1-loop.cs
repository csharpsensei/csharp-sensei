foreach (IReportDestination destination in destinations)
{
    destination.Send(report);
}

// The loop does not know how many there are,
// or what kinds. A fourth means a new class
// and one more line in that list.
