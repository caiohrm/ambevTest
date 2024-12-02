using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;

/// <summary>
/// Handler for processing DeleteSalesCommand requests
/// </summary>
public class DeleteSalesHandler : IRequestHandler<DeleteSalesCommand, DeleteSalesResponse>
{
    private readonly ISalesRepository _SalesRepository;

    /// <summary>
    /// Initializes a new instance of DeleteSalesHandler
    /// </summary>
    /// <param name="SalesRepository">The Sales repository</param>
    /// <param name="validator">The validator for DeleteSalesCommand</param>
    public DeleteSalesHandler(
        ISalesRepository SalesRepository)
    {
        _SalesRepository = SalesRepository;
    }

    /// <summary>
    /// Handles the DeleteSalesCommand request
    /// </summary>
    /// <param name="request">The DeleteSales command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSalesResponse> Handle(DeleteSalesCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSalesValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _SalesRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Sales with ID {request.Id} not found");

        return new DeleteSalesResponse { Success = true };
    }
}
