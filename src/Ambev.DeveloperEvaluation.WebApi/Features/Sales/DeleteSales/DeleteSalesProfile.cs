using Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;

/// <summary>
/// Profile for mapping between Application and API DeleteSales responses
/// </summary>
public class DeleteSalesProfile :Profile
{
    /// <summary>
    /// Initializes the mapping for DeleteSales feature
    /// </summary>
    public DeleteSalesProfile()
    {
        CreateMap<int, Application.Sales.DeleteSales.DeleteSalesCommand>()
            .ConstructUsing(id => new Application.Sales.DeleteSales.DeleteSalesCommand(id));
    }
}