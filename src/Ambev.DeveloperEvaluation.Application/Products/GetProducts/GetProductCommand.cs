using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    /// <summary>
    /// Command for creating a new product
    /// </summary>
    /// <remarks>
    ///  this command is used to capture the required data for getting a product
    ///  It implements <see cref="IRequest{TResponse}"/> to initiate the request
    ///  that return a <see cref="GetProductResult"/>
    ///  
    /// The data provided in this command is validated using the
    /// <see cref="GetProductValidator"/> which extends
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
    /// populated and follow the required rules.
    /// </remarks>
    public class GetProductCommand : IRequest<GetProductResult>
    {
        /// <summary>
        /// The unique identifier of the product to retrieve
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of GetProductCommand
        /// </summary>
        /// <param name="id">The ID of the product to retrieve</param>
        public GetProductCommand(int id)
        {
            Id = id;
        }
    }
}
