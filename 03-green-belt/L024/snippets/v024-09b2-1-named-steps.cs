    private BookingBuilder(string guestName) => _guestName = guestName;

    public static BookingBuilder For(string guestName) => new BookingBuilder(guestName);

    public BookingBuilder ArrivingOn(DateOnly date) { _checkIn = date; return this; }

    public BookingBuilder LeavingOn(DateOnly date) { _checkOut = date; return this; }

    public BookingBuilder InA(RoomType room) { _room = room; return this; }

    public BookingBuilder ForAdults(int adults) { _adults = adults; return this; }

    public BookingBuilder AndChildren(int children) { _children = children; return this; }
