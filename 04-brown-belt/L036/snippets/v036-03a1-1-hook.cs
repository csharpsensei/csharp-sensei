public static string GetGreeting()
{
    return GreetingService.FetchAsync().Result;
}
