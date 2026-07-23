public interface IOrderValidator
{
    ValidationResult Validate(Order order);
}

services.AddScoped<IOrderValidator, NotEmptyValidator>();
services.AddScoped<IOrderValidator, StockValidator>();
services.AddScoped<IOrderValidator, FraudValidator>();
