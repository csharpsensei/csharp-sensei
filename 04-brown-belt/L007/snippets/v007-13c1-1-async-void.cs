static async void FireAndForget()
{
    await Task.Delay(500);
    throw new InvalidOperationException("report failed");
}
