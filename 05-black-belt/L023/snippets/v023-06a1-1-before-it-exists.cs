        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == sourceName,

            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
                _rng.Next(oneIn) == 0
                    ? ActivitySamplingResult.AllDataAndRecorded
                    : ActivitySamplingResult.None,

            ActivityStopped = activity => Recorded.Add(activity)
        };
