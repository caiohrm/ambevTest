using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesValues
{
    /// <summary>
    /// Validator for UpdateSalesValuesCommand
    /// </summary>
    public class UpdateSalesValuesValidator : AbstractValidator<UpdateSalesValuesCommand>
    {
        /// <summary>
        /// Initialize a new instance of the UpdateSalesValuesValidator with defined validation rules
        /// </summary>
        /// <remarks>
        /// Validation rules include:
        /// - Id: must not be empty
        /// </remarks>
        public UpdateSalesValuesValidator()
        {
            RuleFor(Sales => Sales.Id)
                .NotEmpty()
                .WithMessage("Sales Id is required");
        }
    }
}
