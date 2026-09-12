        if (_checkIn is DateOnly arrive && _checkOut is DateOnly leave && leave <= arrive)
        {
            problems.Add("departure " + leave.ToString("yyyy-MM-dd")
                         + " is not after arrival " + arrive.ToString("yyyy-MM-dd"));
        }

        if (_room is RoomType room && _adults + _children > RoomCapacity.Of(room))
        {
            problems.Add((_adults + _children) + " guests in a " + room
                         + " room, which sleeps " + RoomCapacity.Of(room));
        }

        if (_cot && _children == 0)
        {
            problems.Add("a cot needs a child on the booking");
        }
