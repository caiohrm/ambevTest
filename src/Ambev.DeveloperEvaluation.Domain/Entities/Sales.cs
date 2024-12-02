using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sales : BaseEntityInt, ISales
    {
        /// <summary>
        /// Initializes a new instance of the Sales class
        /// </summary>
        public Sales()
        {
            CreatedAt = DateTime.UtcNow;
            Canceled = false;
        }

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
        public string Branch {  get; set; }

        /// <summary>
        /// Products of the Sale
        /// </summary>
        public List<SaleProduct> Product { get; set; }

        /// <summary>
        /// Sale its canceled
        /// </summary>
        public bool Canceled { get; set; } = false;

        /// <summary>
        /// Gets the unique identifier of the Sales
        /// </summary>
        string ISales.Id => Id.ToString();

        /// <summary>
        /// Gets the date and time when the Sales was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time when the Sales was updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets the Sales status
        /// </summary>

        /// <summary>
        /// Performs validation of the Sales entity using the SalesValidator rules
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">CustomerId its not empty</list>
        /// <list type="bullet">Total value</list>
        /// <list type="bullet">Branch its not empty</list>
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new SalesValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail()
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o),
            };
        }

        /// <summary>
        /// Cancel Sales
        /// </summary>
        public void CancelSale()
        {
            Canceled = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
