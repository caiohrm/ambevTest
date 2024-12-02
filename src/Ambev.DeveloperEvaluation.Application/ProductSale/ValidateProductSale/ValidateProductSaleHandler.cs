using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.ValidateProductSale;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.ValidateProductSale
{
    /// <summary>
    /// Handler for processing ValidateProductSaleCommand requests
    /// </summary>
    public class ValidateProductSaleHandler : IRequestHandler<ValidateProductSaleCommand,SaleProduct >
    {
        private readonly IProductSalesRepository _productSalesRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of ValidateProductSaleHandler
        /// </summary>
        /// <param name="ISalesRepository"></param>
        /// <param name="IProductSalesRepository"></param> 
        /// <param name="IProductRepository"></param> 
        /// <param name="mapper"></param>
        public ValidateProductSaleHandler(IProductSalesRepository productSalesRepository,ISalesRepository salesRepository, IProductRepository productRepository, IMapper mapper)
        {
            _productSalesRepository = productSalesRepository;
            _salesRepository = salesRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the ValidateProductSaleCommand request
        /// </summary>
        /// <param name="command"> The ValidateProductSale command</param>
        /// <param name="cancellationToken">Cancelation token</param>
        /// <returns>The created Sales details</returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<SaleProduct> Handle(ValidateProductSaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new ValidateProductSaleValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sale = await _salesRepository.GetByIdAsync(command.SalesId);
            if (sale == null)
                throw new KeyNotFoundException($"Sale with ID {command.SalesId} not found");
            
            var product = await _productRepository.GetByIdAsync(command.ProductId);
            if (product == null)
                throw new KeyNotFoundException($"Product with ID {command.ProductId} not found");

            var saleProduct = _mapper.Map<SaleProduct>(product, opt =>
            {
                opt.Items.Add("SalesId", command.SalesId);
            });
            //now we should Validate the product and calculate the discount
            if (command.Quantity < 4)
                saleProduct.Discount = 0;
            else if (command.Quantity >= 4 && command.Quantity < 10)
                saleProduct.Discount = (command.Quantity * product.Price) * 0.10m;
            else if (command.Quantity >= 10 && command.Quantity <= 20)
                saleProduct.Discount = (command.Quantity * product.Price) * 0.20m;
            else if (command.Quantity > 20)
                throw new ValidationException("Quantity greater than 20 not allowed");
            saleProduct.Total = (command.Quantity * product.Price) - saleProduct.Discount;
            saleProduct.Quantity = command.Quantity;
            
            return saleProduct;
        }
    }
}
