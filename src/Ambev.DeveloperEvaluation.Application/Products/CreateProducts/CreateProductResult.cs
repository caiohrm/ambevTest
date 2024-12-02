using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProducts
{
    /// <summary>
    /// Represents the response returned after sucessfully creating a new product
    /// </summary>
    /// <remarks>
    /// this reponse contains the unique identifier of the newly created product,
    /// which can be used for subsequent operations or reference
    /// </remarks>
    public class CreateProductResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created product
        /// </summary>
        /// <value> A GUID that uniquely identifies the created user in the system</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the product
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the price of the product
        /// </summary>
        public decimal Price { get; set; }
    }
}
