using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntityInt, IProduct
    {
        /// <summary>
        /// Initializes a new instance of the product class
        /// </summary>
        public Product()
        {
            CreatedAt = DateTime.UtcNow;
        }
        /// <summary>
        /// Gets the unique identifier of the product
        /// </summary>
        string IProduct.Id => Id.ToString();

        /// <summary>
        /// Gets or set the product title
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the product price
        /// </summary>
        public decimal Price { get; set; } = decimal.Zero;

        /// <summary>
        /// Gets the date and time when the product was created
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time when the product was updated
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Gets the product status
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Performs validation of the product entity using the ProductValidator rules
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Product format and length</list>
        /// <list type="bullet">Price value</list>
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail()
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o),
            };
        }

        /// <summary>
        /// Disable product
        /// </summary>
        public void Disable()
        {
            Enabled = false;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Enables product
        /// </summary>
        public void Enable()
        {
            Enabled = true;
            UpdatedAt = DateTime.UtcNow;
        }

    }
}
