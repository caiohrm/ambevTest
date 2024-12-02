namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;

/// <summary>
/// Api response model for CreateProduct operation
/// </summary>
public class CreateProductResponse
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created product
    /// </summary>
    /// <value> A GUID that uniquely identifies the created user in the system</value>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the title of the product
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// Gets or sets the price of the product
    /// </summary>
    public decimal Price { get; set; } = decimal.Zero;
}