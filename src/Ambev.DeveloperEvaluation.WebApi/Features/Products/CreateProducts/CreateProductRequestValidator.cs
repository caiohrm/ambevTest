using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;

/// <summary>
/// Validator for CreateProductRequest that defines validations rules for product creation
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules
    /// </summary>
    /// <remarks>
    /// - Price: must be greater than zero
    /// - Title: required, length between 3 and 50 characters
    /// </remarks>
    public CreateProductRequestValidator() 
    {
        RuleFor(product => product.Price).GreaterThan(Decimal.Zero);
        RuleFor(product => product.Title).NotEmpty().Length(3,50);
    }
}