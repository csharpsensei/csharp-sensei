using WhatsNew.Demos;

// Composition root. `dotnet run -- unions` or `dotnet run -- more` runs one
// half of the lesson; a plain `dotnet run` runs both.
string section = args.FirstOrDefault() ?? "all";

if (section is "unions" or "all")
{
    UnionDemo.Run();
}

if (section is "more" or "all")
{
    MoreDemo.Run();
}
