public class Drill
{
    protected int Minutes { get; }
}

// private would hide it from FormsDrill, which needs it.
// public would hand it to the entire application.
// protected is the one that means: my family, nobody else.
