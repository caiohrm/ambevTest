using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleProductValidator : AbstractValidator<SaleProduct>
    {
        public SaleProductValidator()
        {
            RuleFor(Sales => Sales.Quantity).NotEmpty().GreaterThan(0);
            RuleFor(Sales => Sales.UnitPrice)
                .NotEmpty().GreaterThan(0).WithMessage("Unit Price should be greater than 0");
            RuleFor(Sales => Sales.Total)
                .NotEmpty().GreaterThan(0).WithMessage("Total should be greater than 0");
        }
    }
}
