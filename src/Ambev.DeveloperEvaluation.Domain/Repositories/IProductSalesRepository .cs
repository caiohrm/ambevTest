using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for product Sales entity operations
    /// </summary>
    public interface IProductSalesRepository
    {
        /// <summary>
        /// Adds a product to a sale
        /// </summary>
        /// <param name="saleProduct">the product to add</param>
        /// <param name="cancellationToken"></param>
        /// <returns>success if the product was added</returns>
        Task<bool> AddProduct(SaleProduct saleProduct,CancellationToken cancellationToken);

        /// <summary>
        /// Update the product in the sale
        /// </summary>
        /// <param name="saleProduct">the product to add</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> UpdateProduct(SaleProduct saleProduct, CancellationToken cancellationToken);

        /// <summary>
        /// Deletes the product from the sale
        /// </summary>
        /// <param name="salesId">the saleId to add</param>
        /// <param name="productId">the productId to add</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> DeleteProduct(int salesId,int productId, CancellationToken cancellationToken);

        /// <summary>
        /// Get all products on the sale
        /// </summary>
        /// <param name="salesId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<SaleProduct>> GetAllAsync(int salesId, CancellationToken cancellationToken = default);
    }
}
