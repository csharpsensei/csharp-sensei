Console.WriteLine("before await : thread "
    + Environment.CurrentManagedThreadId);

await Task.Delay(500);

Console.WriteLine("after  await : thread "
    + Environment.CurrentManagedThreadId);
