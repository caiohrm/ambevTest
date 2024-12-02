using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProducts;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.GetProducts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

/// <summary>
/// Controller for managing products operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductController : BaseController
{

    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ProductController
    /// </summary>
    /// <param name="mediator">the mediator instance</param>
    /// <param name="mapper">the Automapper instance</param>
    public ProductController(IMediator mediator, IMapper mapper)
    {
        this._mediator = mediator;
        this._mapper = mapper;
    }

    /// <summary>
    /// Creates a new product
    /// </summary>
    /// <param name="request">the product creation request</param>
    /// <param name="cancellationToken">Cancelation token</param>
    /// <returns>The created product details</returns>
    [HttpPost]
    //[Authorize(Roles = nameof(UserRole.Admin)+"," + nameof(UserRole.Manager))]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateProductResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateProductCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created succesfully",
            Data = _mapper.Map<CreateProductResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a product by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the product</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetProductResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProduct([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new GetProductRequest { Id = id };
        var validator = new GetProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetProductCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetProductResponse>
        {
            Success = true,
            Message = "Product retrieved successfully",
            Data = _mapper.Map<GetProductResponse>(response)
        });
    }

    /// <summary>
    /// Deletes a product by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the product was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProduct([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new DeleteProductRequest { Id = id };
        var validator = new DeleteProductRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteProductCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Product deleted successfully"
        });
    }


}