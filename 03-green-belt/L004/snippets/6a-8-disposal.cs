public sealed class SqlOrderRepository : IOrderRepository, IDisposable
{
    private readonly SqlConnection _connection;

    public SqlOrderRepository(string connectionString)
        => _connection = new SqlConnection(connectionString);

    public void Dispose() => _connection.Dispose();
}

services.AddScoped<IOrderRepository, SqlOrderRepository>();

using (var scope = provider.CreateScope())
{
    var repository = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
}

services.AddSingleton<IEmailSender>(new SmtpEmailSender("smtp.contoso.com", 587));
