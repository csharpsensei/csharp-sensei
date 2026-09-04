        Log.Line("Pass 1: what await really does");

        Task<double> pending = AverageReading.ReadAverageAsync("north", "south");

        Log.Line("  [main]   the call came back, and the answer is not here yet");
        Log.Line("  [main]   nothing is blocked: we are on " + Log.Where);

        double average = await pending;

        Log.Line("  [main]   the answer arrived: " + average);
        Log.Line("  [main]   and we came back on " + Log.Where);
