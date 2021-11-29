using Commerce.Core.RequestModels;
using FluentValidation;

namespace Commerce.Lib.Customers.Validator;

public class CustomerRequestValidator: AbstractValidator<CustomerRequest>
{
    const string nameErrorCode = "1000001";
    public CustomerRequestValidator()
    {
        RuleFor(m => m.Name).NotNull().NotEmpty().WithErrorCode(nameErrorCode);
    }
}