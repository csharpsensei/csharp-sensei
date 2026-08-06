public interface INamed
{
    string Name { get; }   // NOT a field
}

// A promise that the class provides
// something you can read.
// The class supplies the storage.

// Wanting a field here means you want
// a base class.
