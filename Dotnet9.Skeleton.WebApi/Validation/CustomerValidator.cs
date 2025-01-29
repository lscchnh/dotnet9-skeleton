using Dotnet9.Skeleton.WebApi.Models;
using FluentValidation;

namespace Dotnet9.Skeleton.WebApi.Validation;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
    }
}
