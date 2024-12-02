using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesValues
{
    /// <summary>
    /// Command for creating a new Sales
    /// </summary>
    /// <remarks>
    ///  this command is used to update the values of the Sales
    ///  It implements <see cref="IRequest{TResponse}"/> to initiate the request
    ///  that return a <see cref="UpdateSalesValuesResult"/>
    ///  
    /// The data provided in this command is validated using the
    /// <see cref="UpdateSalesValuesValidator"/> which extends
    /// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly
    /// populated and follow the required rules.
    /// </remarks>
    public class UpdateSalesValuesCommand : IRequest<UpdateSalesValuesResult>
    {
        /// <summary>
        /// The unique identifier of the Sales to retrieve
        /// </summary>
        public int Id { get; set; }
    }
}
