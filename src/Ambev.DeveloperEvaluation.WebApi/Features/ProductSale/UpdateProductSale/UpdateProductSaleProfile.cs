using Ambev.DeveloperEvaluation.Application.ProductSale.UpdateProductSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.UpdateProductSale;

/// <summary>
/// Profile for mapping between Application and API UpdateProductSale responses
/// </summary>
public class UpdateProductSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mapping for CreateProduts feature
    /// </summary>
    public UpdateProductSaleProfile()
    {
        CreateMap<UpdateProductSaleRequest, UpdateProductSaleCommand>()
            .ForMember(d=> d.ProductId,opt=> opt.MapFrom((s, d, _, context) =>
            {
                return (int)context.Items["ProductId"];
            }))
            .ForMember(d => d.SalesId, opt => opt.MapFrom((s, d, _, context) =>
            {
                return (int)context.Items["SalesId"];
            }));
        CreateMap<UpdateProductSaleResult, UpdateProductSaleResponse>();
    }
}