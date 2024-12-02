using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

/// <summary>
/// Validator for GetSalesRequest that defines validations rules for Sales creation
/// </summary>
public class GetSalesRequestValidator : AbstractValidator<GetSalesRequest>
{
    /// <summary>
    /// Initializes a new instance of the GetSalesRequestValidator with defined validation rules
    /// </summary>
    /// <remarks>
    /// - Id: must not be empty
    /// </remarks>
    public GetSalesRequestValidator() 
    {
        RuleFor(Sales => Sales.Id)
            .NotEmpty()
            .WithMessage("Sales Id is required");
    }
}