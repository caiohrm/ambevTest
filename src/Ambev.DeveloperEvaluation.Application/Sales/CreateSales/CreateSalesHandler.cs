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

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSales
{
    /// <summary>
    /// Handler for processing CreateSalesCommand requests
    /// </summary>
    public class CreateSalesHandler : IRequestHandler<CreateSalesCommand, CreateSalesResult>
    {
        private readonly ISalesRepository _SalesRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of CreateSalesHandler
        /// </summary>
        /// <param name="SalesRepository"></param>
        /// <param name="mapper"></param>
        public CreateSalesHandler(ISalesRepository SalesRepository, IMapper mapper)
        {
            this._SalesRepository = SalesRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Handles the CreateSalesCommand request
        /// </summary>
        /// <param name="command"> The CreateSales command</param>
        /// <param name="cancellationToken">Cancelation token</param>
        /// <returns>The created Sales details</returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<CreateSalesResult> Handle(CreateSalesCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateSalesValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            //TODO add validation to check if user exists
            var sales = _mapper.Map<Ambev.DeveloperEvaluation.Domain.Entities.Sales>(command);
            sales = await this._SalesRepository.CreateAsync(sales, cancellationToken);
            var result = _mapper.Map<CreateSalesResult>(sales);
            return result;
        }
    }
}
