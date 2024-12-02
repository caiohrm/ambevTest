using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.AddProductSale
{
    /// <summary>
    /// Command for adding product to a sale
    /// </summary>
    /// <remarks>
    ///  this command is used to capture the required data for adding product to a Sales,
    ///  product id and quantity.
    ///  It implements <see cref="IRequest{TResponse}"/> to initiate the request
    ///  that return a <see cref="AddProductSaleResult"/>
    ///  
    /// The data provided in this command is validated using the
    /// <see cref="AddProductSaleValidator"/> which extends
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
    /// populated and follow the required rules.
    /// </remarks>
    public class AddProductSaleCommand : IRequest<AddProductSaleResult>
    {
        /// <summary>
        /// Gets or sets the SaleId
        /// </summary>
        public int SalesId { get; set; }

        /// <summary>
        /// Gets or sets the product of the Sales to be created
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the products to be created
        /// </summary>
        public int Quantity { get; set; }
    }
}
