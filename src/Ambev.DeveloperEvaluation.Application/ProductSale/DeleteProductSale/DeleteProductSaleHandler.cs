using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesValues;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.DeleteProductSale
{
    /// <summary>
    /// Handler for processing DeleteProductSaleCommand requests
    /// </summary>
    public class DeleteProductSaleHandler : IRequestHandler<DeleteProductSaleCommand, DeleteProductSaleResult>
    {
        private readonly IProductSalesRepository _productSalesRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of DeleteProductSaleHandler
        /// </summary>
        /// <param name="ISalesRepository"></param>
        /// <param name="IProductSalesRepository"></param> 
        /// <param name="IProductRepository"></param> 
        /// <param name="mapper"></param>
        public DeleteProductSaleHandler(IProductSalesRepository productSalesRepository, ISalesRepository salesRepository, IProductRepository productRepository, IMapper mapper, IMediator mediator)
        {
            _productSalesRepository = productSalesRepository;
            _salesRepository = salesRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _mediator = mediator;

        }

        /// <summary>
        /// Handles the DeleteProductSaleCommand request
        /// </summary>
        /// <param name="command"> The DeleteProductSale command</param>
        /// <param name="cancellationToken">Cancelation token</param>
        /// <returns>The created Sales details</returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<DeleteProductSaleResult> Handle(DeleteProductSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new DeleteProductSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _salesRepository.GetByIdAsync(command.SalesId);
            if (sale == null)
                throw new KeyNotFoundException($"Sale with ID {command.SalesId} not found");

            var product = await _productRepository.GetByIdAsync(command.ProductId);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {command.ProductId} not found");

            var salesProduct = _mapper.Map<SaleProduct>(command);
            var success = await _productSalesRepository.DeleteProduct(command.SalesId,command.ProductId, cancellationToken);
            var result = _mapper.Map<DeleteProductSaleResult>(success);

            var updateSalesValuesCommand = _mapper.Map<UpdateSalesValuesCommand>(command);
            await _mediator.Send(updateSalesValuesCommand, cancellationToken);

            return result;
        }
    }
}
