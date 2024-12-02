namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// Api response model for GetProduct operation
/// </summary>
public class GetProductResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly Getd product
    /// </summary>
    /// <value> A GUID that uniquely identifies the Getd user in the system</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or set the product title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the product price
    /// </summary>
    public decimal Price { get; set; } = decimal.Zero;

    /// <summary>
    /// Gets the date and time when the product was created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets the date and time when the product was updated
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Gets the product status
    /// </summary>
    public bool Enabled { get; set; } = true;
}