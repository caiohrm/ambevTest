using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    /// <summary>
    /// Profile for mapping between User entity and GetProductResponse
    /// </summary>
    public class GetProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for GetProduct operation
        /// </summary>
        public GetProductProfile()
        {
            CreateMap<GetProductCommand, Product>();
            CreateMap<Product, GetProductResult>();
        }
    }
}
