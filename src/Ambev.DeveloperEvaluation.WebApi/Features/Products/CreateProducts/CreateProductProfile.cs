using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;

/// <summary>
/// Profile for mapping between Application and API CreateProduct responses
/// </summary>
public class CreateProductProfile :Profile
{
    /// <summary>
    /// Initializes the mapping for CreateProduts feature
    /// </summary>
    public CreateProductProfile()
    {
        CreateMap<CreateProductRequest, CreateProductCommand>();
        CreateMap<CreateProductResult, CreateProductResponse>();
    }
}