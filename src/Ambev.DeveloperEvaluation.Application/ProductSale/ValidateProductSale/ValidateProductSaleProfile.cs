using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.ProductSale.ValidateProductSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.ValidateProductSale
{
    /// <summary>
    /// Profile for mapping between User entity and ValidateProductSaleResponse
    /// </summary>
    public class ValidateProductSaleProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for ValidateProductSale operation
        /// </summary>
        public ValidateProductSaleProfile()
        {
            CreateMap<Product, Ambev.DeveloperEvaluation.Domain.Entities.SaleProduct>()
                .ForMember(x => x.Id, src => src.Ignore())
                .ForMember(x=> x.UnitPrice, src => src.MapFrom(s=> s.Price))
                .ForMember(x => x.ProductId, src => src.MapFrom(s => s.Id))
                .ForMember(x => x.SalesId, src => src.MapFrom((s,d,_,context) => (int)context.Items["SalesId"]));
            CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.SaleProduct, ValidateProductSaleResult>();
        }
    }
}
