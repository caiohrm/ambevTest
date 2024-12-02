using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Price).GreaterThan(Decimal.Zero);
            RuleFor(product => product.Title)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Title must be at least 3 characters long")
                .MaximumLength(50).WithMessage("Title cannot be longer than 50 characters");

        }
    }
}
