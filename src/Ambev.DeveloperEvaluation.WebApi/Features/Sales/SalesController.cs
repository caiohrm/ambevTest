using Ambev.DeveloperEvaluation.Application.Products.DeleteProducts;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSales;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSales;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.DeleteProducts;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSales;
using Ambev.DeveloperEvaluation.WebApi.Middleware;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales;

/// <summary>
/// Controller for managing sales operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of SalesController
    /// </summary>
    /// <param name="mediator">the mediator instance</param>
    /// <param name="mapper">the Automapper instance</param>
    public SalesController(IMediator mediator, IMapper mapper)
    {
        this._mediator = mediator;
        this._mapper = mapper;
    }

    /// <summary>
    /// Creates a new sales
    /// </summary>
    /// <param name="request">the sale creation request</param>
    /// <param name="cancellationToken">Cancelation token</param>
    /// <returns>The created sales details</returns>
    [HttpPost]
    //[Authorize(Roles = nameof(UserRole.Admin)+"," + nameof(UserRole.Manager))]
    [ServiceFilter(typeof(ActionFilterMessageBroker))]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSalesResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [Authorize()]
    public async Task<IActionResult> CreateSales([FromBody] CreateSalesRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSalesRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSalesCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);
        return Created(string.Empty, new ApiResponseWithData<CreateSalesResponse>
        {
            Success = true,
            Message = "Sales created succesfully",
            Data = _mapper.Map<CreateSalesResponse>(response)
        });
    }


    /// <summary>
    /// Retrieves a sales by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the sales</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sales details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSalesResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSales([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new GetSalesRequest { Id = id };
        var validator = new GetSalesRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSalesCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetSalesResponse>
        {
            Success = true,
            Message = "Sales retrieved successfully",
            Data = _mapper.Map<GetSalesResponse>(response)
        });
    }

    /// <summary>
    /// Deletes a Sales by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the Sales to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the Sales was deleted</returns>
    [HttpDelete("{id}")]
    [ServiceFilter(typeof(ActionFilterMessageBroker))]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [Authorize(Roles = nameof(UserRole.Admin) + "," + nameof(UserRole.Manager))]
    public async Task<IActionResult> DeleteSales([FromRoute] int id, CancellationToken cancellationToken)
    {
        var request = new DeleteSalesRequest { Id = id };
        var validator = new DeleteSalesRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSalesCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "Sales deleted successfully"
        });
    }
}