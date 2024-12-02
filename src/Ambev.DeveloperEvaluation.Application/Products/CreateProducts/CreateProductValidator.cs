using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProducts
{
    /// <summary>
    /// Validator for CreateProductCommand that defines validation rules for product creation command
    /// </summary>
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        /// <summary>
        /// Initialize a new instance of the CreateProductValidator with defined validation rules
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Price: must be greater than zero
        /// - Title: required, length between 3 and 50 characters
        /// </remarks>
        public CreateProductValidator()
        {
            RuleFor(product => product.Price).GreaterThan(Decimal.Zero);
            RuleFor(product => product.Title).NotEmpty().Length(3, 50);
        }
    }
}
