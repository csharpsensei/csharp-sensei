                case 0:
                    First = _awaiter.GetResult();
                    _awaiter = Station.ReadAsync(B).GetAwaiter();
                    State = 1;
                    Park();
                    return;

    private void Park()
    {
        ReadAverageMachine self = this;
        Builder.AwaitOnCompleted(ref _awaiter, ref self);
    }
