public sealed class LateFeeCalculatorTests
{
    public void FeeInPence_ReturnedOnDueDate_ChargesNothing()
    public void FeeInPence_ReturnedEarly_ChargesNothing()
    public void FeeInPence_OneDayLate_ChargesTwentyPence()
    public void FeeInPence_TenDaysLate_ChargesTwoPounds()
    public void FeeInPence_TwentyFiveDaysLate_ChargesExactlyTheCap()
    public void FeeInPence_ThirtyDaysLate_CapsAtFivePounds()
}
