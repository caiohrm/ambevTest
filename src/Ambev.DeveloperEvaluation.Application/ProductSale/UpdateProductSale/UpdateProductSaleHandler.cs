using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesValues;
using Ambev.DeveloperEvaluation.Application.Sales.ValidateProductSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.UpdateProductSale
{
    /// <summary>
    /// Handler for processing UpdateProductSaleCommand requests
    /// </summary>
    public class UpdateProductSaleHandler : IRequestHandler<UpdateProductSaleCommand, UpdateProductSaleResult>
    {
        private readonly IProductSalesRepository _productSalesRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        /// <summary>
        /// Initializes a new instance of UpdateProductSaleHandler
        /// </summary>
        /// <param name="ISalesRepository"></param>
        /// <param name="IProductSalesRepository"></param> 
        /// <param name="IProductRepository"></param> 
        /// <param name="mapper"></param>
        public UpdateProductSaleHandler(IProductSalesRepository productSalesRepository,IMediator mediator, IMapper mapper)
        {
            _productSalesRepository = productSalesRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        /// <summary>
        /// Handles the UpdateProductSaleCommand request
        /// </summary>
        /// <param name="command"> The UpdateProductSale command</param>
        /// <param name="cancellationToken">Cancelation token</param>
        /// <returns>The created Sales details</returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<UpdateProductSaleResult> Handle(UpdateProductSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var saleProductValidation = _mapper.Map<ValidateProductSaleCommand>(command);
            var productSale = await _mediator.Send(saleProductValidation, cancellationToken);

            
            var success = await _productSalesRepository.UpdateProduct(productSale, cancellationToken);

            var updateSalesValuesCommand = _mapper.Map<UpdateSalesValuesCommand>(command);
            await _mediator.Send(updateSalesValuesCommand, cancellationToken);

            var result = _mapper.Map<UpdateProductSaleResult>(success);
            return result;
        }
    }
}
