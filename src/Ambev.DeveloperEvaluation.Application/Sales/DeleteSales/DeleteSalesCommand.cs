using Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;

/// <summary>
/// Command for deleting a Sales
/// </summary>
public record DeleteSalesCommand : IRequest<DeleteSalesResponse>
{
    /// <summary>
    /// The unique identifier of the Sales to delete
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteSalesCommand
    /// </summary>
    /// <param name="id">The ID of the Sales to delete</param>
    public DeleteSalesCommand(int id)
    {
        Id = id;
    }
}
