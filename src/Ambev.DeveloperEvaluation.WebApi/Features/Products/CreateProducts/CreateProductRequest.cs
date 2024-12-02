namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;
public class CreateProductRequest
{
    
    public string Title { get; set; } = string.Empty;

    public decimal Price { get; set; } = decimal.Zero;
}