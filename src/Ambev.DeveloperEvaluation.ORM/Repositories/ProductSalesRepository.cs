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
    /// Implementation of IProductSalesRepository using Entity Framework core
    /// </summary>
    public class ProductSalesRepository : IProductSalesRepository
    {
        private readonly DefaultContext _context;
        /// <summary>
        /// Initializes a new instance of ProductSalesRepository
        /// </summary>
        /// <param name="context">the database context</param>
        /// <param name="salesRepository">the sales repository</param>
        public ProductSalesRepository(DefaultContext context)
        {
            this._context = context;

        }

        /// <summary>
        /// Adds a product to a sale
        /// </summary>
        /// <param name="saleProduct">the product to add</param>
        /// <param name="cancellationToken"></param>
        /// <returns>success if the product was added</returns>
        public async Task<bool> AddProduct(SaleProduct saleProduct, CancellationToken cancellationToken)
        {
            await _context.SaleProducts.AddAsync(saleProduct, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        /// <summary>
        /// Get product on the sale
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="salesId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SaleProduct> GetByidAsync(int productId, int salesId, CancellationToken cancellationToken = default)
        {
            return await _context.SaleProducts.FirstOrDefaultAsync(o => o.ProductId == productId && o.SalesId == salesId && o.Canceled == false, cancellationToken);
        }

        /// <summary>
        /// Get all products on the sale
        /// </summary>
        /// <param name="salesId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SaleProduct>> GetAllAsync(int salesId, CancellationToken cancellationToken = default)
        {
            return _context.SaleProducts.Where(o => o.SalesId == salesId && o.Canceled == false);
        }

        /// <summary>
        /// Updates the product in the sales
        /// </summary>
        /// <param name="salesProduct"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>sucess if the product was updated</returns>
        public async Task<bool> UpdateProduct(SaleProduct salesProduct, CancellationToken cancellationToken)
        {
            var item = await GetByidAsync(salesProduct.ProductId, salesProduct.SalesId);
            if (item == null)
                return false;
            salesProduct.Id = item.Id;
            _context.Entry(item).CurrentValues.SetValues(salesProduct);
            _context.Entry(item).Property(x => x.Id).IsModified = false;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Deletes the product from the sale
        /// </summary>
        /// <param name="salesProduct"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>sucess if the product was deleted</returns>
        public async Task<bool> DeleteProduct(int salesId, int productId, CancellationToken cancellationToken)
        {
            var item = await GetByidAsync(productId, salesId);
            if (item == null)
                return false;
            item.CancelItem();
            _context.SaleProducts.Update(item);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
