public sealed class GuardedArchiveProxy(IReportArchive inner, User user)
    : IReportArchive
{
    public string Read(string reportId)
    {
        if (reportId.StartsWith("pay-") && !user.Roles.Contains("finance"))
            throw new AccessDeniedException("needs the finance role");

        return inner.Read(reportId);
    }
}
