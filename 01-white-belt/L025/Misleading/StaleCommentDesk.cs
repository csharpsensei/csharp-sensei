using NamingAndComments.Lending;

namespace NamingAndComments.Misleading;

/// <summary>
/// The comment below says three days. The code says whatever
/// <see cref="LendingPolicy.GraceDays"/> says, which is seven. The comment was
/// true once. Nothing has told it otherwise. Kept, wrong, on purpose.
/// </summary>
public static class StaleCommentDesk
{
    // A loan is overdue three days after the due date.
    public static bool IsOverdue(int daysPastDue)
    {
        return daysPastDue > LendingPolicy.GraceDays;
    }
}
