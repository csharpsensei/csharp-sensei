        _listener = new ActivityListener
        {
            ShouldListenTo = source => source.Name == sourceName,

            Sample = (ref ActivityCreationOptions<ActivityContext> options) =>
                ActivitySamplingResult.AllDataAndRecorded,

            ActivityStopped = activity => Completed.Add(activity)
        };

        ActivitySource.AddActivityListener(_listener);
