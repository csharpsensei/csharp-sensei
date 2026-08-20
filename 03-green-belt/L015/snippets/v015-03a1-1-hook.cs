    // The package sits on a read only medium. There is no write to
    // perform, and nothing this method could return would be true.
    public void Write(string name, byte[] content)
        => throw new NotImplementedException("PackageStore is read only");
