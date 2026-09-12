        if (trace.Status == ActivityStatusCode.Error)
        {
            return Decision.Error;
        }

        if (trace.Duration.TotalMilliseconds >= SlowMilliseconds)
        {
            return Decision.Slow;
        }

        if (IsWatched(trace))
        {
            return Decision.Vip;
        }

        bool keep = _rng.Next(BaselineOneIn) == 0;
        return keep ? Decision.Baseline : Decision.Dropped;
