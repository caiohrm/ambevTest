using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts
{
    /// <summary>
    /// Handler for processing GetProductCommand requests
    /// </summary>
    public class GetProductHandler : IRequestHandler<GetProductCommand, GetProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetProductHandler
        /// </summary>
        /// <param name="productRepository"></param>
        /// <param name="mapper"></param>
        public GetProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            this._productRepository = productRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Handles the GetProductCommand request
        /// </summary>
        /// <param name="command"> The GetProduct command</param>
        /// <param name="cancellationToken">Cancelation token</param>
        /// <returns>The product details</returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<GetProductResult> Handle(GetProductCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetProductValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            
            var user = await this._productRepository.GetByIdAsync(command.Id, cancellationToken);
            if (user == null)
                throw new KeyNotFoundException($"Product with ID {command.Id} not found");

            return _mapper.Map<GetProductResult>(user);
        }
    }
}
