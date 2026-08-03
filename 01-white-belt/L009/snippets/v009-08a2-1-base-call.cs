public FormsDrill(string name, int minutes, int formCount)
    : base(name, minutes)
{
    _formCount = formCount;
}

// Take what you need, keep your own piece,
// hand the rest up with base(...).
