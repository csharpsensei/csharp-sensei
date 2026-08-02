app.MapPost("/seed", async (TrafficSeeder seeder, ...) =>
    Results.Ok(new { seeded = await seeder.SeedAsync(count, ...) }));

// 400 realistic checkouts. A p95 over nine requests
// is not a p95.
