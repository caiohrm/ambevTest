namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.DeleteProductSale;
public class DeleteProductSaleRequest
{
    /// <summary>
    /// The Sale Id to delete the product
    /// </summary>
    public int SalesId { get; set; } = 0;
    
    /// <summary>
    /// The product id to be deleted from the sale
    /// </summary>
    public int ProductId { get; set; } = 0;
}