        Log.Line("  [method] started on " + Log.Where + ", nothing awaited yet");

        double first = await Station.ReadAsync(a);
        Log.Line("  [method] first reading back, on " + Log.Where);

        double second = await Station.ReadAsync(b);
        Log.Line("  [method] second reading back, on " + Log.Where);

        return (first + second) / 2;
