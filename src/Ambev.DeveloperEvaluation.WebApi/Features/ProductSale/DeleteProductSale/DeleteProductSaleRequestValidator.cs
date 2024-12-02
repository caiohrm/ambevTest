using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.DeleteProductSale;

/// <summary>
/// Validator for DeleteProductSaleRequest that defines validations rules for product sales creation
/// </summary>
public class DeleteProductSaleRequestValidator : AbstractValidator<DeleteProductSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the DeleteProductSaleRequestValidator with defined validation rules
    /// </summary>
    /// <remarks>
    /// - SalesId: must be greater than zero
    /// - ProductId: must be greater than zero
    
    /// </remarks>
    public DeleteProductSaleRequestValidator()
    {
        RuleFor(x => x.SalesId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Sales ID is required");

        RuleFor(x => x.ProductId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("Product ID is required");
    }
}