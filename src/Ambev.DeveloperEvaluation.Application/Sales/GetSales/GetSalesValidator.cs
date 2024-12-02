using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    /// <summary>
    /// Validator for GetSalesCommand
    /// </summary>
    public class GetSalesValidator : AbstractValidator<GetSalesCommand>
    {
        /// <summary>
        /// Initialize a new instance of the GetSalesValidator with defined validation rules
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Id: must not be empty
        /// </remarks>
        public GetSalesValidator()
        {
            RuleFor(Sales => Sales.Id)
                .NotEmpty()
                .WithMessage("Sales Id is required");
        }
    }
}
