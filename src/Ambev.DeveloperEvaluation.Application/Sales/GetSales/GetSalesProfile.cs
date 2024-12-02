using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    /// <summary>
    /// Profile for mapping between User entity and GetSalesResponse
    /// </summary>
    public class GetSalesProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetSales operation
        /// </summary>
        public GetSalesProfile()
        {
            CreateMap<GetSalesCommand, Ambev.DeveloperEvaluation.Domain.Entities.Sales>();
            CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Sales, GetSalesResult>();
        }
    }
}
