using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProducts
{
    /// <summary>
    /// Profile for mapping between User entity and CreateProductResponse
    /// </summary>
    public class CreateProductProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateProduct operation
        /// </summary>
        public CreateProductProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, CreateProductResult>();
        }
    }
}
