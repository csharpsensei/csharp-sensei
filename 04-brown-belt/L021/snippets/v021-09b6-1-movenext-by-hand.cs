    public void MoveNext()
    {
        Log.Line("  [by hand] MoveNext, state " + State + ", on " + Log.Where);

        try
        {
            switch (State)
            {
                case -1:
                    _awaiter = Station.ReadAsync(A).GetAwaiter();
                    State = 0;
                    Park();
                    return;
