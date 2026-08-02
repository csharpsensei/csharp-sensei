builder.Logging.AddSimpleConsole(o =>
{
    o.IncludeScopes = true;   // without this, scopes print NOTHING
    o.SingleLine    = true;
});
