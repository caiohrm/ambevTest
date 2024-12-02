using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProducts
{
    /// <summary>
    /// Handler for processing CreateProductCommand requests
    /// </summary>
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateProductHandler
        /// </summary>
        /// <param name="productRepository"></param>
        /// <param name="mapper"></param>
        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateProductCommand request
        /// </summary>
        /// <param name="command"> The CreateProduct command</param>
        /// <param name="cancellationToken">Cancelation token</param>
        /// <returns>The created product details</returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateProductValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            var product = _mapper.Map<Product>(command);
            var createdProdcut = await this._productRepository.CreateAsync(product, cancellationToken);
            var result = _mapper.Map<CreateProductResult>(createdProdcut);
            return result;
        }
    }
}
