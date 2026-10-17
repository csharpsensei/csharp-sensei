string? answer = context.Run(async () =>
{
    string greeting = await GreetingService.FetchAsync();
    return greeting + "  |  resumed on the context thread: "
        + Describe.YesNo(context.IsCurrentThread);
}, patience);
