using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;

/// <summary>
/// Profile for mapping between Application and API GetProduct responses
/// </summary>
public class GetProductProfile : Profile
{
    /// <summary>
    /// Initializes the mapping for GetProduts feature
    /// </summary>
    public GetProductProfile()
    {
        CreateMap<int, Application.Products.GetProducts.GetProductCommand>()
            .ConstructUsing(id => new Application.Products.GetProducts.GetProductCommand(id));
        CreateMap<GetProductResult, GetProductResponse>();
    }
}