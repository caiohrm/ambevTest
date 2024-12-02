using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesValues;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.UpdateProductSale
{
    /// <summary>
    /// Handler for processing UpdateSalesValuesCommand requests
    /// </summary>
    public class UpdateSalesValuesHandler : IRequestHandler<UpdateSalesValuesCommand, UpdateSalesValuesResult>
    {
        private readonly ISalesRepository _salesRepository;
        private readonly IProductSalesRepository _productSalesRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of UpdateSalesValuesHandler
        /// </summary>
        /// <param name="SalesRepository"></param>
        /// <param name="mapper"></param>
        public UpdateSalesValuesHandler(IProductSalesRepository productSalesRepository, ISalesRepository salesRepository, IMapper mapper)
        {
            _salesRepository = salesRepository;
            _productSalesRepository = productSalesRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the UpdateSalesValuesCommand request
        /// </summary>
        /// <param name="command"> The UpdateSalesValues command</param>
        /// <param name="cancellationToken">Cancelation token</param>
        /// <returns>The Sales details</returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<UpdateSalesValuesResult> Handle(UpdateSalesValuesCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateSalesValuesValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var sales = await _salesRepository.GetByIdAsync(command.Id, cancellationToken);
            if (sales == null)
                throw new KeyNotFoundException($"Sales with ID {command.Id} not found");
            var products = await _productSalesRepository.GetAllAsync(command.Id, cancellationToken);

            sales.Total = products.Sum(x => x.Total);
            await _salesRepository.UpdateAsync(sales, cancellationToken);
            return _mapper.Map<UpdateSalesValuesResult>(sales);
        }
    }
}
