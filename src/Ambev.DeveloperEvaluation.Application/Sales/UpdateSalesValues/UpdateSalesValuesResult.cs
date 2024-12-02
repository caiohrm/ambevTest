using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesValues
{
    /// <summary>
    /// Represents the response returned after sucessfully updating the Sales
    /// </summary>
    /// <remarks>
    /// this reponse contains the unique identifier of the  Sales,
    /// which can be used for subsequent operations or reference
    /// </remarks>
    public class UpdateSalesValuesResult
    {
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

        /// <summary>
        /// Products of the Sale
        /// </summary>
        public List<SaleProduct> Product { get; set; }

        /// <summary>
        /// Sale its canceled
        /// </summary>
        public bool Canceled { get; set; }
    }
}
