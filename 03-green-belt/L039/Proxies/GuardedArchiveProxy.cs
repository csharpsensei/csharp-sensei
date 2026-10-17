using ProxyPattern.Archive;
using ProxyPattern.Security;

namespace ProxyPattern.Proxies;

/// <summary>
/// A protection proxy. Same shape again; it decides whether the call may
/// reach the real thing at all. Payroll reports need the finance role.
/// </summary>
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
