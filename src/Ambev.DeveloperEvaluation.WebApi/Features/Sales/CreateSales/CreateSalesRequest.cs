namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;
public class CreateSalesRequest
{
    /// <summary>
    /// Gets or sets the customerId of the Sales to be created
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the branch of the Sales to be created
    /// </summary>
    public string Branch { get; set; } = string.Empty;
}