using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    /// <summary>
    /// Represents the response returned after sucessfully creating a new product
    /// </summary>
    /// <remarks>
    /// this reponse contains the unique identifier of the newly Getd product,
    /// which can be used for subsequent operations or reference
    /// </remarks>
    public class GetProductResult
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
}
