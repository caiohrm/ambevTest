namespace Ambev.DeveloperEvaluation.Application.ProductSale.UpdateProductSale;

public class UpdateSaleProductObject
{
    /// <summary>
    /// Gets or sets the salesId
    /// </summary>
    public int SalesId { get; set; }


    /// <summary>
    /// Gets the date and time when the Sales product was created
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the Sales product was updated
    /// </summary>
    public DateTime UpdatedAt { get; set; }

    /// <summary>
    /// Id of the product
    /// </summary>
    public int ProductId { get; set; }
    /// <summary>
    /// Quantity of the itens sold
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// Unit price of the item at the moment of the sale
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Discount applied in the item
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Total of the products
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Item its canceled of the sale
    /// </summary>
    public bool Canceled { get; set; }
}