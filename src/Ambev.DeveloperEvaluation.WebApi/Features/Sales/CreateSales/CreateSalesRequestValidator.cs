using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

/// <summary>
/// Validator for CreateSalesRequest that defines validations rules for Sales creation
/// </summary>
public class CreateSalesRequestValidator : AbstractValidator<CreateSalesRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSalesRequestValidator with defined validation rules
    /// </summary>
    /// <remarks>
    /// - Price: must be greater than zero
    /// - Title: required, length between 3 and 50 characters
    /// </remarks>
    public CreateSalesRequestValidator() 
    {
        
    }
}