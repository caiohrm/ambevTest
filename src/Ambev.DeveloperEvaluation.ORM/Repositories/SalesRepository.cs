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
    /// Implementation of ISalesRepository using Entity Framework core
    /// </summary>
    public class SalesRepository : ISalesRepository
    {
        private readonly DefaultContext _context;
        /// <summary>
        /// Initializes a new instance of SalesRepository
        /// </summary>
        /// <param name="context">the database context</param>
        public SalesRepository(DefaultContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Creates a new Sales in the database
        /// </summary>
        /// <param name="Sales">the Sales to create</param>
        /// <param name="cancellationToken">cancelation token</param>
        /// <returns>The created Sales</returns>
        public async Task<Sales> CreateAsync(Sales Sales, CancellationToken cancellationToken = default)
        {
            await _context.Sales.AddAsync(Sales, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Sales;
        }

        /// <summary>
        /// Retrieves a Sales by their unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the Sales</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The Sales if found, null otherwise</returns>
        public async Task<Sales?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _context.Sales.Include(x=> x.Customer).Include(x=>x.Product).FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
        }

        /// <summary>
        /// Set Sales as disabled on database
        /// </summary>
        /// <param name="id">The unique identifier of the Sales to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>True if the Sales was disabled, false if not found</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var Sales = await GetByIdAsync(id, cancellationToken);
            if (Sales == null)
                return false;
            Sales.CancelSale();
            _context.Sales.Update(Sales);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        /// <summary>
        /// Updates the sales
        /// </summary>
        /// <param name="sale"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>sucess if the sale was updated</returns>
        public async Task<bool> UpdateAsync(Sales sale, CancellationToken cancellationToken)
        {
            var item = await GetByIdAsync(sale.Id);
            if (item == null)
                return false;

            _context.Entry(item).CurrentValues.SetValues(sale);
            _context.SaveChanges();
            return true;
        }
    }
}
