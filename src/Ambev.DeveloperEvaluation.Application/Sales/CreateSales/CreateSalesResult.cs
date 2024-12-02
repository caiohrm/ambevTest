using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales
{
    /// <summary>
    /// Represents the response returned after sucessfully creating a new Sales
    /// </summary>
    /// <remarks>
    /// this reponse contains the unique identifier of the newly created Sales,
    /// which can be used for subsequent operations or reference
    /// </remarks>
    public class CreateSalesResult
    {
        /// <summary>
        /// Gets or sets the unique identifier of the newly created Sales
        /// </summary>
        /// <value> A GUID that uniquely identifies the created user in the system</value>
        public int Id { get; set; }

        /// <summary>
        /// Customer that made the purchase
        /// </summary>
        public User Customer { get; set; }

        /// <summary>
        /// Customer Id
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Total sale amount
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Branch where the sale was made
        /// </summary>
        public string Branch { get; set; }
    }
}
