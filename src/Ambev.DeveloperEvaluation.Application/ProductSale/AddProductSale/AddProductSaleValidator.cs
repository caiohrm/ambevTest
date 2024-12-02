using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.AddProductSale
{
    /// <summary>
    /// Validator for AddProductSaleCommand that defines validation rules for product Sales creation command
    /// </summary>
    public class AddProductSaleValidator : AbstractValidator<AddProductSaleCommand>
    {
        /// <summary>
        /// Initialize a new instance of the AddProductSaleValidator with defined validation rules
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductId: must be greater than zero
        /// - Quantity: required, greater than zero
        /// - SalesId: required, greater than zero
        /// </remarks>
        public AddProductSaleValidator()
        {
            RuleFor(Sales => Sales.SalesId).NotEmpty().GreaterThan(0);
            RuleFor(Sales => Sales.ProductId).NotEmpty().GreaterThan(0);
            RuleFor(Sales => Sales.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
