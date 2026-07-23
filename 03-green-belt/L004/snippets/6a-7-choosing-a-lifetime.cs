services.AddSingleton<IClock, SystemClock>();
services.AddSingleton<IEmailSender, SmtpEmailSender>();
services.AddSingleton<IMemoryCache, MemoryCache>();

services.AddScoped<IOrderRepository, SqlOrderRepository>();
services.AddScoped<IUnitOfWork, EfUnitOfWork>();
services.AddScoped<ICurrentUser, HttpCurrentUser>();

services.AddTransient<IOrderValidator, StockValidator>();
services.AddTransient<IPdfRenderer, QuestPdfRenderer>();
