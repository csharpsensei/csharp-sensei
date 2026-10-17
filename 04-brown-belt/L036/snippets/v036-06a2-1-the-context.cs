public override void Post(SendOrPostCallback callback, object? state) =>
    _queue.Add((callback, state));
