Publisher publisher = new Publisher(disk);
Console.WriteLine(Row("Publisher", "DiskFileStore",
                      publisher.Publish("cover.thumb.png")));

// Publisher wrong = new Publisher(package);
// That line does not compile. PackageStore implements IReadFiles and
// nothing else, so it is not an IWriteFiles. Uncomment it and the
// failure arrives from the compiler instead of from a customer.
