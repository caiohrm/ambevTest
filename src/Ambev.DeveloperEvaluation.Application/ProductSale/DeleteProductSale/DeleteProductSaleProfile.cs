using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.ProductSale.AddProductSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesValues;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.DeleteProductSale
{
    /// <summary>
    /// Profile for mapping between User entity and DeleteProductSaleResponse
    /// </summary>
    public class DeleteProductSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for DeleteProductSale operation
        /// </summary>
        public DeleteProductSaleProfile()
        {
            CreateMap<DeleteProductSaleCommand, SaleProduct>();
            CreateMap<SaleProduct, DeleteProductSaleResult>();
            CreateMap<bool, DeleteProductSaleResult>()
            .ConstructUsing(sucess => new DeleteProductSaleResult(sucess));
            CreateMap<DeleteProductSaleCommand, UpdateSalesValuesCommand>()
                .ForMember(x => x.Id, src => src.MapFrom(x => x.SalesId));
        }
    }
}
