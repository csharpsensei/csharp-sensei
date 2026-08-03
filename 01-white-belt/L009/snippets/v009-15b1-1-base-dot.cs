public override string Describe()
    => $"{base.Describe()}, {_rounds} rounds";

// Overriding does not have to mean discarding.
// base.Describe() is the ONLY way to reach the
// version you replaced.

// Calling Describe() here would call THIS method
// again. Forever.
