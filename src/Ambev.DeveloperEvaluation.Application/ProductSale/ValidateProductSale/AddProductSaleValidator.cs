using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.ValidateProductSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.ValidateProductSale
{
    /// <summary>
    /// Validator for ValidateProductSaleCommand that defines validation rules for product Sales creation command
    /// </summary>
    public class ValidateProductSaleValidator : AbstractValidator<ValidateProductSaleCommand>
    {
        /// <summary>
        /// Initialize a new instance of the ValidateProductSaleValidator with defined validation rules
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductId: must be greater than zero
        /// - Quantity: required, greater than zero
        /// - SalesId: required, greater than zero
        /// </remarks>
        public ValidateProductSaleValidator()
        {
            RuleFor(Sales => Sales.SalesId).NotEmpty().GreaterThan(0);
            RuleFor(Sales => Sales.ProductId).NotEmpty().GreaterThan(0);
            RuleFor(Sales => Sales.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
