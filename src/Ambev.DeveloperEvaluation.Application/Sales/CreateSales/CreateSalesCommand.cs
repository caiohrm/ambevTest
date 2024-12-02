using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales
{
    /// <summary>
    /// Command for creating a new Sales
    /// </summary>
    /// <remarks>
    ///  this command is used to capture the required data for creating a Sales,
    ///  including title and price.
    ///  It implements <see cref="IRequest{TResponse}"/> to initiate the request
    ///  that return a <see cref="CreateSalesResult"/>
    ///  
    /// The data provided in this command is validated using the
    /// <see cref="CreateSalesValidator"/> which extends
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
    /// populated and follow the required rules.
    /// </remarks>
    public class CreateSalesCommand : IRequest<CreateSalesResult>
    {
        /// <summary>
        /// Gets or sets the customerId of the Sales to be created
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the branch of the Sales to be created
        /// </summary>
        public string Branch { get; set; } = string.Empty;
    }
}
