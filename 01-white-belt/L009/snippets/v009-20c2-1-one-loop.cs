foreach (var drill in session)
{
    Console.WriteLine(drill.Describe());
    total += drill.CaloriesBurned();
}

// No switch. No if. No type check.
// Add a fifth drill and this loop does not change.
