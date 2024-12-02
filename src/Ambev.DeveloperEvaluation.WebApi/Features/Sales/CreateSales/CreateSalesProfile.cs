using Ambev.DeveloperEvaluation.Application.Sales.CreateSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;

/// <summary>
/// Profile for mapping between Application and API CreateSales responses
/// </summary>
public class CreateSalesProfile :Profile
{
    /// <summary>
    /// Initializes the mapping for CreateProduts feature
    /// </summary>
    public CreateSalesProfile()
    {
        CreateMap<CreateSalesRequest, CreateSalesCommand>();
        CreateMap<CreateSalesResult, CreateSalesResponse>();
    }
}