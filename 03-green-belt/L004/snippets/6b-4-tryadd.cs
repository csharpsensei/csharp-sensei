services.TryAddScoped<IClock, SystemClock>();

services.TryAddEnumerable(
    ServiceDescriptor.Scoped<IOrderValidator, StockValidator>());

services.Replace(
    ServiceDescriptor.Singleton<IEmailSender, SendGridEmailSender>());

services.RemoveAll<IPdfRenderer>();
services.AddScoped<IPdfRenderer, QuestPdfRenderer>();
