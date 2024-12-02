using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesValues;
using Ambev.DeveloperEvaluation.Application.Sales.ValidateProductSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.AddProductSale
{
    /// <summary>
    /// Handler for processing AddProductSaleCommand requests
    /// </summary>
    public class AddProductSaleHandler : IRequestHandler<AddProductSaleCommand, AddProductSaleResult>
    {
        private readonly IProductSalesRepository _productSalesRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        /// <summary>
        /// Initializes a new instance of AddProductSaleHandler
        /// </summary>
        /// <param name="IProductSalesRepository"></param> 
        /// <param name="mapper"></param>
        public AddProductSaleHandler(IProductSalesRepository productSalesRepository, IMediator mediator, IMapper mapper)
        {
            _productSalesRepository = productSalesRepository;
            this._mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the AddProductSaleCommand request
        /// </summary>
        /// <param name="command"> The AddProductSale command</param>
        /// <param name="cancellationToken">Cancelation token</param>
        /// <returns>The created Sales details</returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<AddProductSaleResult> Handle(AddProductSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new AddProductSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            var productSaleExists = await _productSalesRepository.GetByidAsync(command.ProductId, command.SalesId, cancellationToken);
            if(productSaleExists != null)
                throw new ValidationException("Product already exists in sale");

            var saleProductValidation = _mapper.Map<ValidateProductSaleCommand>(command);
            var productSale = await _mediator.Send(saleProductValidation, cancellationToken);

            var success = await _productSalesRepository.AddProduct(productSale, cancellationToken);

            var updateSalesValuesCommand = _mapper.Map<UpdateSalesValuesCommand>(command);
            await _mediator.Send(updateSalesValuesCommand, cancellationToken);

            var result = _mapper.Map<AddProductSaleResult>(success);
            return result;
        }
    }
}
