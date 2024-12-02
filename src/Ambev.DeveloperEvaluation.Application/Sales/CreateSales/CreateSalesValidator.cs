using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales
{
    /// <summary>
    /// Validator for CreateSalesCommand that defines validation rules for Sales creation command
    /// </summary>
    public class CreateSalesValidator : AbstractValidator<CreateSalesCommand>
    {
        /// <summary>
        /// Initialize a new instance of the CreateSalesValidator with defined validation rules
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Price: must be greater than zero
        /// - Title: required, length between 3 and 50 characters
        /// </remarks>
        public CreateSalesValidator()
        {
            RuleFor(Sales => Sales.CustomerId).NotEmpty();
            RuleFor(Sales => Sales.Branch).NotEmpty().Length(3, 50);
        }
    }
}
