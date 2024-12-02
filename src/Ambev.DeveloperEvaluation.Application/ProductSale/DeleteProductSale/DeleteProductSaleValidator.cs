using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.DeleteProductSale
{
    /// <summary>
    /// Validator for DeleteProductSaleCommand that defines validation rules for product Sales delete command
    /// </summary>
    public class DeleteProductSaleValidator : AbstractValidator<DeleteProductSaleCommand>
    {
        /// <summary>
        /// Initialize a new instance of the DeleteProductSaleValidator with defined validation rules
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - ProductId: must be greater than zero
        /// - SalesId: required, greater than zero
        /// </remarks>
        public DeleteProductSaleValidator()
        {
            RuleFor(Sales => Sales.ProductId).NotEmpty().GreaterThan(0);
            RuleFor(Sales => Sales.SalesId).NotEmpty().GreaterThan(0);
        }
    }
}
