public sealed class PostageCalculatorTests
{
    public void PriceInPence_OneKiloExactly_ChargesSmallParcelRate()
    public void PriceInPence_JustOverOneKilo_ChargesMediumParcelRate()
    public void PriceInPence_TwoKilosExactly_ChargesMediumParcelRate()
    public void PriceInPence_Express_AddsTwoHundredAndFiftyPence()
    public void PriceInPence_OverFiveKilos_Throws()
    public void PriceInPence_ZeroGrams_Throws()
    }
