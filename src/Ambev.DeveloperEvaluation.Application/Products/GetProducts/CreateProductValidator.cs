using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    /// <summary>
    /// Validator for GetProductCommand
    /// </summary>
    public class GetProductValidator : AbstractValidator<GetProductCommand>
    {
        /// <summary>
        /// Initialize a new instance of the GetProductValidator with defined validation rules
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Id: must not be empty
        /// </remarks>
        public GetProductValidator()
        {
            RuleFor(product => product.Id)
                .NotEmpty()
                .WithMessage("Product Id is required");
        }
    }
}
