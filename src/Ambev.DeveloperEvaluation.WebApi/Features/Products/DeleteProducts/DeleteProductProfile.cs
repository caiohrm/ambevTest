using Ambev.DeveloperEvaluation.Application.Products.DeleteProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProducts;

/// <summary>
/// Profile for mapping between Application and API DeleteProduct responses
/// </summary>
public class DeleteProductProfile :Profile
{
    /// <summary>
    /// Initializes the mapping for DeleteProducts feature
    /// </summary>
    public DeleteProductProfile()
    {
        CreateMap<int, Application.Products.DeleteProducts.DeleteProductCommand>()
            .ConstructUsing(id => new Application.Products.DeleteProducts.DeleteProductCommand(id));
    }
}