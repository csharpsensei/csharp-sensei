builder.Services.AddScoped<IBookingStore, InMemoryBookingStore>();
builder.Services.AddScoped<BookingService>();
