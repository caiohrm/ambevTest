using Ambev.DeveloperEvaluation.Application.ProductSale.AddProductSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.AddProductSale;

/// <summary>
/// Profile for mapping between Application and API AddProductSale responses
/// </summary>
public class AddProductSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mapping for CreateProduts feature
    /// </summary>
    public AddProductSaleProfile()
    {
        CreateMap<AddProductSaleRequest, AddProductSaleCommand>()
            .ForMember(d => d.SalesId, opt => opt.MapFrom((s, d, _, context) =>
            {
                return (int)context.Items["SalesId"];
            })); ;
        CreateMap<AddProductSaleResult, AddProductSaleResponse>();
    }
}