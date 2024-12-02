using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProducts;

/// <summary>
/// Validator for DeleteProductRequest that defines validations rules for product creation
/// </summary>
public class DeleteProductRequestValidator : AbstractValidator<DeleteProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the DeleteProductRequestValidator with defined validation rules
    /// </summary>
    /// <remarks>
    /// - Id: must not be empty
    /// </remarks>
    public DeleteProductRequestValidator()
    {
        RuleFor(product => product.Id)
            .NotEmpty()
            .WithMessage("Product Id is required");
    }
}
