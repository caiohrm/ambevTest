using Ambev.DeveloperEvaluation.Application.ProductSale.DeleteProductSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.DeleteProductSale;

/// <summary>
/// Profile for mapping between Application and API DeleteProductSale responses
/// </summary>
public class DeleteProductSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mapping for CreateProduts feature
    /// </summary>
    public DeleteProductSaleProfile()
    {
        CreateMap<DeleteProductSaleRequest, DeleteProductSaleCommand>()
            .ForMember(d => d.SalesId, opt => opt.MapFrom((s, d, _, context) =>
            {
                return (int)context.Items["SalesId"];
            }));
        CreateMap<DeleteProductSaleResult, DeleteProductSaleResponse>();
    }
}