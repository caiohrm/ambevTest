using Ambev.DeveloperEvaluation.Application.Products.DeleteProducts;
using Ambev.DeveloperEvaluation.Application.ProductSale.AddProductSale;
using Ambev.DeveloperEvaluation.Application.ProductSale.DeleteProductSale;
using Ambev.DeveloperEvaluation.Application.ProductSale.UpdateProductSale;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.AddProductSale;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.DeleteProductSale;
using Ambev.DeveloperEvaluation.WebApi.Features.ProductSale.UpdateProductSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.ProductSale;

/// <summary>
/// Controller for managing product sales operations
/// </summary>
[ApiController]
[Route("api/sales")]
public class ProductSalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of SalesController
    /// </summary>
    /// <param name="mediator">the mediator instance</param>
    /// <param name="mapper">the Automapper instance</param>
    public ProductSalesController(IMediator mediator, IMapper mapper)
    {
        this._mediator = mediator;
        this._mapper = mapper;
    }

    /// <summary>
    /// Creates a new sales
    /// </summary>
    /// <param name="salesId">The unique identifier of the sales to add the product</param>
    /// <param name="request">the product sale creation request</param>
    /// <param name="cancellationToken">Cancelation token</param>
    /// <returns>The created product sales details</returns>
    [HttpPost("{salesId}/product")]
    //[Authorize(Roles = nameof(UserRole.Admin)+"," + nameof(UserRole.Manager))]
    [ProducesResponseType(typeof(ApiResponseWithData<AddProductSaleResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProductSales([FromRoute] int salesId, [FromBody] AddProductSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new AddProductSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<AddProductSaleCommand>(request, opt =>
        {
            opt.Items.Add("SalesId", salesId);
        });
        var response = await _mediator.Send(command, cancellationToken);
        return Created(string.Empty, new ApiResponseWithData<AddProductSaleResponse>
        {
            Success = true,
            Message = "ProductSales added succesfully",
            Data = _mapper.Map<AddProductSaleResponse>(response)
        });
    }



    /// <summary>
    /// Deletes a product from Sales by their ID
    /// </summary>
    /// <param name="salesId">The unique identifier of the sales</param>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the Sales was deleted</returns>
    [HttpDelete("{salesId}/product/{productId}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSales([FromRoute] int salesId, [FromRoute] int productId, CancellationToken cancellationToken)
    {
        var request = new DeleteProductSaleRequest { SalesId = salesId, ProductId = productId };
        var validator = new DeleteProductSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteProductSaleCommand>(request, opt =>
            {
                opt.Items.Add("SalesId", salesId);
            }); ;
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Product deleted from sale successfully"
        });
    }

    /// <summary>
    /// Update a product from Sales by their ID
    /// </summary>
    /// <param name="salesId">The unique identifier of the sales</param>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the Sales was deleted</returns>
    [HttpPut("{salesId}/product/{productId}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutSales([FromRoute] int salesId, [FromRoute] int productId, [FromBody] UpdateProductSaleRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateProductSaleRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<UpdateProductSaleCommand>(request, opt =>
        {
            opt.Items.Add("SalesId", salesId);
            opt.Items.Add("ProductId", productId);
        }); 
        var sucess = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Product updated from sale successfully"
        });
    }
}