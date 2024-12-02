using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Common;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleProduct : BaseEntityInt, ISaleProduct
    {
        /// <summary>
        /// Initializes a new instance of the Sales class
        /// </summary>
        public SaleProduct()
        {
            CreatedAt = DateTime.UtcNow;
            Canceled = false;
        }
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
        /// Product in the sale
        /// </summary>
        public Product Product { get; set; }
        
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
        public decimal Total {  get; set; }

        /// <summary>
        /// Item its canceled of the sale
        /// </summary>
        public bool Canceled { get; set; }

        string ISaleProduct.Id => Id.ToString();

        public void CancelItem()
        {
            Canceled = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
