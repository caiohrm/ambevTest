using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    /// <summary>
    /// Repository interface for Sales entity operations
    /// </summary>
    public interface ISalesRepository
    {
        /// <summary>
        /// Creates a new Sales in the repository
        /// </summary>
        /// <param name="user">The Sales to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created Sales</returns>
        Task<Sales> CreateAsync(Sales Sales, CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves a Sales by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the Sales</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sales if found, null otherwise</returns>
        Task<Sales?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Set Sales as disabled on database
        /// </summary>
        /// <param name="id">The unique identifier of the Sales to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the Sales was disabled, false if not found</returns>
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the sale 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> UpdateAsync(Sales sale, CancellationToken cancellationToken = default);
    }
}
