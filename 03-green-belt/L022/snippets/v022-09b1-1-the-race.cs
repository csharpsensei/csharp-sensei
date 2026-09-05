    public static RateTable Instance
    {
        get
        {
            if (_instance is null)
            {
                // Only here to make the race reliable. Take it out and the
                // same thing still happens, just not on every run.
                Thread.Sleep(60);
                _instance = new RateTable();
            }

            return _instance;
        }
    }
