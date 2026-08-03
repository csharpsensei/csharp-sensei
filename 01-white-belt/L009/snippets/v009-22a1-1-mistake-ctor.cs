public SummaryDrill(string name, int minutes)
    : base(name, minutes)
{
    CachedSummary = Describe();   // virtual, in a ctor
}

// 1. base constructor runs
// 2. it calls Describe()
// 3. dispatch sends that to the OVERRIDE
// 4. which reads a field nobody has assigned yet
