using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SalesValidator : AbstractValidator<Sales>
    {
        public SalesValidator()
        {
            RuleFor(Sales => Sales.CustomerId).NotEmpty();
            RuleFor(Sales => Sales.Total)
                .NotEmpty().GreaterThan(0).WithMessage("Total should be greater than 0");
            RuleFor(Sales => Sales.Branch)
                .NotEmpty().WithMessage("Branch cannot be empty");
        }
    }
}
