static async Task<int> GetCountAsync()
{
    return 5;
}

static Task<int> GetCountAsync()
{
    return Task.FromResult(5);
}
