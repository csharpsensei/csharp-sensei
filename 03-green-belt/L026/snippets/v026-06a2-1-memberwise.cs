    /// <summary>
    /// A shallow copy. A new sheet, with every field's value copied
    /// across. For Kit, Starters and Substitutes the value IS the
    /// reference, so the copy shares all three with this sheet.
    /// </summary>
    public TeamSheet ShallowCopy()
    {
        return (TeamSheet)MemberwiseClone();
    }
