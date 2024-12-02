using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    /// <summary>
    /// Implementation of IProductRepository using Entity Framework core
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly DefaultContext _context;
        /// <summary>
        /// Initializes a new instance of ProductRepository
        /// </summary>
        /// <param name="context">the database context</param>
        public ProductRepository(DefaultContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Creates a new product in the database
        /// </summary>
        /// <param name="product">the product to create</param>
        /// <param name="cancellationToken">cancelation token</param>
        /// <returns>The created product</returns>
        public async Task<Product> CreateAsync(Product product, CancellationToken cancellationToken = default)
        {
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product;
        }

        /// <summary>
        /// Retrieves a product by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The product if found, null otherwise</returns>
        public async Task<Product?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Products.FirstOrDefaultAsync(o => o.Id == id && o.Enabled, cancellationToken);
        }

        /// <summary>
        /// Set product as disabled on database
        /// </summary>
        /// <param name="id">The unique identifier of the product to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the product was disabled, false if not found</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await GetByIdAsync(id, cancellationToken);
            if (product == null)
                return false;
            product.Enabled = false;
            _context.Products.Update(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
