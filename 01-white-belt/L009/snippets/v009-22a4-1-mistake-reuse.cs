public class Invoice : List<LineItem>   // wrong

// It compiles. You get Add and Count for free.
// You also get Clear, Insert, Reverse and Sort,
// on your invoice, forever, to everybody.

public class Invoice                    // right
{
    private readonly List<LineItem> _lines = [];
}

// Inherit when it IS one. Hold one when it HAS one.
