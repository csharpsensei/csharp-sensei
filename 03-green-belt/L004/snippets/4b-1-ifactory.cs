public interface IPaymentGatewayFactory
{
    IPaymentGateway Create(string method);
}
