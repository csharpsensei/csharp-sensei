public int DaysTo(string postcode)
{
    for (int attempt = 1; ; attempt++)
    {
        try
        {
            return inner.DaysTo(postcode);
        }
        catch (TransientQuoteException) when (attempt < maxAttempts)
        {
            Retries++;
        }
    }
}
