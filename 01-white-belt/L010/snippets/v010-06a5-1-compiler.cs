public class ConsoleDestination : IReportDestination
{
    // Send left out on purpose.
}

// error CS0535: 'ConsoleDestination' does not
// implement interface member
// 'IReportDestination.Send(string)'

// A promise the compiler checks.
