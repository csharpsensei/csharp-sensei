await GreetingService.FetchAsync().ConfigureAwait(false);
return "resumed on the context thread: "
    + Describe.YesNo(context.IsCurrentThread);
