using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProducts
{
    /// <summary>
    /// Command for creating a new product
    /// </summary>
    /// <remarks>
    ///  this command is used to capture the required data for creating a product,
    ///  including title and price.
    ///  It implements <see cref="IRequest{TResponse}"/> to initiate the request
    ///  that return a <see cref="CreateProductResult"/>
    ///  
    /// The data provided in this command is validated using the
    /// <see cref="CreateProductValidator"/> which extends
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateProductCommand : IRequest<CreateProductResult>
    {
        /// <summary>
        /// Gets or sets the title of the product to be created
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the product to be created
        /// </summary>
        public decimal Price { get; set; } = decimal.Zero;
    }
}
