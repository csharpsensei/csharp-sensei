using DependencyInjection.Domain;

namespace DependencyInjection.Abstractions;

public interface IOrderRepository
{
    void Save(Order order);
    void SaveInvoice(Invoice invoice);
}