namespace DependencyInjection.Abstractions;

public interface IPaymentGatewayFactory
{
    IPaymentGateway Create(string method);
}