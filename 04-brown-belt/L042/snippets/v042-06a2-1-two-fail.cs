Task<Quote[]> all = Task.WhenAll(asking);

string rethrown;
try
{
    await all;
    rethrown = "nothing";
}
catch (FirmClosedException ex)
{
    rethrown = ex.Message;
