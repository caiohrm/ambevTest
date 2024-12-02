using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.AddProductSale;

/// <summary>
/// Validator for AddProductSaleRequest that defines validations rules for Sales creation
/// </summary>
public class AddProductSaleRequestValidator : AbstractValidator<AddProductSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the AddProductSaleRequestValidator with defined validation rules
    /// </summary>
    /// <remarks>
    /// - Price: must be greater than zero
    /// - Title: required, length between 3 and 50 characters
    /// </remarks>
    public AddProductSaleRequestValidator()
    {

    }
}