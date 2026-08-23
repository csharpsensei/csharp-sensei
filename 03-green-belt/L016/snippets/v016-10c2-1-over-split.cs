public interface ICountDaysLate { int Days(DateOnly due, DateOnly today); }

public interface IChargePerDay { int Pence(int days); }

public interface IFormatMoney { string Format(int pence); }

public interface IBuildLine { string Line(Loan loan, string money); }

public interface IMakeOverdueReviews { OverSplitReview Make(); }
