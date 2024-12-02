using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales
{
    /// <summary>
    /// Profile for mapping between User entity and CreateSalesResponse
    /// </summary>
    public class CreateSalesProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for CreateSales operation
        /// </summary>
        public CreateSalesProfile()
        {
            CreateMap<CreateSalesCommand, Ambev.DeveloperEvaluation.Domain.Entities.Sales>();
            CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Sales, CreateSalesResult>();
        }
    }
}
