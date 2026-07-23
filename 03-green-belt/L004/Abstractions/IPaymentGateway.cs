using DependencyInjection.Domain;

namespace DependencyInjection.Abstractions;

public interface IPaymentGateway
{
    PaymentResult Charge(int customerId, decimal amount);
}