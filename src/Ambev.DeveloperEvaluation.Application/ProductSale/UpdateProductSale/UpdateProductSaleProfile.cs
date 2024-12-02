using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.ProductSale.AddProductSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesValues;
using Ambev.DeveloperEvaluation.Application.Sales.ValidateProductSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.UpdateProductSale
{
    /// <summary>
    /// Profile for mapping between User entity and UpdateProductSaleResponse
    /// </summary>
    public class UpdateProductSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateProductSale operation
        /// </summary>
        public UpdateProductSaleProfile()
        {
            CreateMap<UpdateProductSaleCommand, ValidateProductSaleCommand>();
            CreateMap<SaleProduct, UpdateProductSaleResult>();
            CreateMap<bool, UpdateProductSaleResult>()
            .ConstructUsing(sucess => new UpdateProductSaleResult(sucess));
            CreateMap<UpdateProductSaleCommand, UpdateSalesValuesCommand>()
                .ForMember(x => x.Id, src => src.MapFrom(x => x.SalesId));
        }
    }
}
