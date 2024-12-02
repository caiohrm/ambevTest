using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

/// <summary>
/// Api response model for CreateSales operation
/// </summary>
public class CreateSalesResponse
{

    /// <summary>
    /// Gets or sets the Sale Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Customer that made the purchase
    /// </summary>
    public User Customer { get; set; }

    /// <summary>
    /// Customer Id
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Total sale amount
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Branch where the sale was made
    /// </summary>
    public string Branch { get; set; }

    /// <summary>
    /// Products of the Sale
    /// </summary>
    public List<SaleProduct> Product { get; set; }

    /// <summary>
    /// Sale its canceled
    /// </summary>
    public bool Canceled { get; set; }
}