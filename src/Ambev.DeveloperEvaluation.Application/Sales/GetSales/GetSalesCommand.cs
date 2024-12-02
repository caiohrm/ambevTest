using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    /// <summary>
    /// Command for creating a new Sales
    /// </summary>
    /// <remarks>
    ///  this command is used to capture the required data for getting a Sales
    ///  It implements <see cref="IRequest{TResponse}"/> to initiate the request
    ///  that return a <see cref="GetSalesResult"/>
    ///  
    /// The data provided in this command is validated using the
    /// <see cref="GetSalesValidator"/> which extends
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
    /// populated and follow the required rules.
    /// </remarks>
    public class GetSalesCommand : IRequest<GetSalesResult>
    {
        /// <summary>
        /// The unique identifier of the Sales to retrieve
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Initializes a new instance of GetSalesCommand
        /// </summary>
        /// <param name="id">The ID of the Sales to retrieve</param>
        public GetSalesCommand(int id)
        {
            Id = id;
        }
    }
}
