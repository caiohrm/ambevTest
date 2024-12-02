using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesValues;
using Ambev.DeveloperEvaluation.Application.Sales.ValidateProductSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.AddProductSale
{
    /// <summary>
    /// Profile for mapping between User entity and AddProductSaleResponse
    /// </summary>
    public class AddProductSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for AddProductSale operation
        /// </summary>
        public AddProductSaleProfile()
        {
            CreateMap<AddProductSaleCommand, ValidateProductSaleCommand>();
            CreateMap<SaleProduct, AddProductSaleResult>();
            CreateMap<bool, AddProductSaleResult>()
            .ConstructUsing(sucess => new AddProductSaleResult(sucess));
            CreateMap<AddProductSaleCommand, UpdateSalesValuesCommand>()
                .ForMember(x => x.Id, src => src.MapFrom(x => x.SalesId));

        }
    }
}
