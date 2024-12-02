using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// Validator for GetProductRequest that defines validations rules for product creation
/// </summary>
public class GetProductRequestValidator : AbstractValidator<GetProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the GetProductRequestValidator with defined validation rules
    /// </summary>
    /// <remarks>
    /// - Id: must not be empty
    /// </remarks>
    public GetProductRequestValidator() 
    {
        RuleFor(product => product.Id)
            .NotEmpty()
            .WithMessage("Product Id is required");
    }
}