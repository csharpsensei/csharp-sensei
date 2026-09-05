    private static readonly RateTableOnce _instance = new RateTableOnce();
    private static int _constructions;

    public static int Constructions => Volatile.Read(ref _constructions);

    public static RateTableOnce Instance => _instance;
