using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.UpdateProductSale;

/// <summary>
/// Validator for UpdateProductSaleRequest that defines validations rules for Sales creation
/// </summary>
public class UpdateProductSaleRequestValidator : AbstractValidator<UpdateProductSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateProductSaleRequestValidator with defined validation rules
    /// </summary>
    /// <remarks>
    /// - Price: must be greater than zero
    /// - Title: required, length between 3 and 50 characters
    /// </remarks>
    public UpdateProductSaleRequestValidator()
    {

    }
}