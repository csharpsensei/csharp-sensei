public double Celsius
{
    get => _celsius;
    set
    {
        if (value < -273.15)
            throw new ArgumentOutOfRangeException(nameof(value));

        _celsius = value;
    }
}
