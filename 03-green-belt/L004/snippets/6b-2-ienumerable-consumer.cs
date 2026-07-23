public sealed class OrderValidationPipeline
{
    private readonly IEnumerable<IOrderValidator> _validators;

    public OrderValidationPipeline(IEnumerable<IOrderValidator> validators)
        => _validators = validators;

    public ValidationResult Validate(Order order)
    {
        foreach (var validator in _validators)
        {
            var result = validator.Validate(order);

            if (!result.IsValid)
                return result;
        }

        return ValidationResult.Success;
    }
}
