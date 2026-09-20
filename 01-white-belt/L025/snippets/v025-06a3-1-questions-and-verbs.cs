    public decimal UnpaidFees { get; }

    public bool HasUnpaidFees => UnpaidFees > 0m;

    public bool CanBorrow => !HasUnpaidFees;

    public string DescribeStanding()
    {
        return Member.Name + (CanBorrow ? " may borrow" : " owes fees");
    }
