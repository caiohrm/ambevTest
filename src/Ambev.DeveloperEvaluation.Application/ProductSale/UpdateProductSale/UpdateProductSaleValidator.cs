using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.UpdateProductSale
{
    /// <summary>
    /// Validator for UpdateProductSaleCommand that defines validation rules for product Sales creation command
    /// </summary>
    public class UpdateProductSaleValidator : AbstractValidator<UpdateProductSaleCommand>
    {
        /// <summary>
        /// Initialize a new instance of the UpdateProductSaleValidator with defined validation rules
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductId: must be greater than zero
        /// - Quantity: required, greater than zero
        /// </remarks>
        public UpdateProductSaleValidator()
        {
            RuleFor(Sales => Sales.ProductId).NotEmpty().GreaterThan(0);
            RuleFor(Sales => Sales.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
