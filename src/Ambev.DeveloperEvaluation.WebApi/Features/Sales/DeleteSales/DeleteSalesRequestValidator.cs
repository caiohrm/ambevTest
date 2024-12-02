using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;

/// <summary>
/// Validator for DeleteSalesRequest that defines validations rules for Sales creation
/// </summary>
public class DeleteSalesRequestValidator : AbstractValidator<DeleteSalesRequest>
{
    /// <summary>
    /// Initializes a new instance of the DeleteSalesRequestValidator with defined validation rules
    /// </summary>
    /// <remarks>
    /// - Id: must not be empty
    /// </remarks>
    public DeleteSalesRequestValidator()
    {
        RuleFor(Sales => Sales.Id)
            .NotEmpty()
            .WithMessage("Sales Id is required");
    }
}
