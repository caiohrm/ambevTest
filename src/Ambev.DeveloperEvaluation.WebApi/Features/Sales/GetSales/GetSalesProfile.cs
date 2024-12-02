using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;

/// <summary>
/// Profile for mapping between Application and API GetSales responses
/// </summary>
public class GetSalesProfile : Profile
{
    /// <summary>
    /// Initializes the mapping for GetProduts feature
    /// </summary>
    public GetSalesProfile()
    {
        CreateMap<int, Application.Sales.GetSales.GetSalesCommand>()
            .ConstructUsing(id => new Application.Sales.GetSales.GetSalesCommand(id));
        CreateMap<GetSalesResult, GetSalesResponse>();
    }
}