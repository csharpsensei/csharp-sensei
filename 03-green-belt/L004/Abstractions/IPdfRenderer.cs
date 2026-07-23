using DependencyInjection.Domain;

namespace DependencyInjection.Abstractions;

public interface IPdfRenderer
{
    Invoice Render(Order order);
}