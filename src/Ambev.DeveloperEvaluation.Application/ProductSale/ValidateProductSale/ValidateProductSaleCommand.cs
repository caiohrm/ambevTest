using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.ProductSale.ValidateProductSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ValidateProductSale
{
    /// <summary>
    /// Command to Validate product to a sale
    /// </summary>
    /// <remarks>
    ///  this command is used to capture the required data for Validate product to a Sales,
    ///  product id and quantity.
    ///  It implements <see cref="IRequest{TResponse}"/> to initiate the request
    ///  that return a <see cref="ValidateProductSaleResult"/>
    ///  
    /// The data provided in this command is validated using the
    /// <see cref="ValidateProductSaleValidator"/> which extends
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
    /// populated and follow the required rules.
    /// </remarks>
    public class ValidateProductSaleCommand : IRequest<SaleProduct>
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
