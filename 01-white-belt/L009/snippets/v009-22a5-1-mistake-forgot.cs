public class FormsDrill : Drill
{
    public string Describe() => "...";   // no override
}

// It compiles. It warns. And it quietly behaves
// like `new` — so it works in your test, where the
// variable is a FormsDrill, and fails in the loop,
// where the variable is a Drill.

// Do not ignore CS0114.
