using Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;

/// <summary>
/// Validator for DeleteSalesCommand
/// </summary>
public class DeleteSalesValidator : AbstractValidator<DeleteSalesCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteSalesCommand
    /// </summary>
    public DeleteSalesValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sales ID is required");
    }
}
