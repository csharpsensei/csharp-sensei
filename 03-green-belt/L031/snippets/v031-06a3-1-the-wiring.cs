builder.Services.AddSingleton<IBookingStore, InMemoryBookingStore>();
builder.Services.AddScoped<BookingService>();

WebApplication app = builder.Build();
app.Urls.Add(url);
RepairShopEndpoints.Map(app);
