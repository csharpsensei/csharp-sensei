using ProxyPattern.Archive;
using ProxyPattern.Security;

namespace ProxyPattern.Reporting;

/// <summary>Tries one read and reports the outcome as a line.</summary>
public static class Attempt
{
    public static string Read(IReportArchive archive, string reportId)
    {
        try
        {
            archive.Read(reportId);
            return "allowed";
        }
        catch (AccessDeniedException ex)
        {
            return "refused, " + ex.Message;
        }
    }
}
