// FormsSession.cs        line 14
public bool ShouldCancel() => Attendees < 1;   // fixed

// SparringSession.cs     line 14
public bool ShouldCancel() => Attendees < 2;   // not fixed

// Two files. One rule. One of them is wrong, and to the
// compiler these are two unrelated classes that happen
// to look alike.
