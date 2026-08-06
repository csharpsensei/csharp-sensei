if (_destination is FileDestination file)
{
    file.FlushToDisk();
}

// The type says interface.
// The code says otherwise.
// It compiles. It runs. It is gone.

// Fix the interface, do not work around it.
