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

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    /// <summary>
    /// Handler for processing GetSalesCommand requests
    /// </summary>
    public class GetSalesHandler : IRequestHandler<GetSalesCommand, GetSalesResult>
    {
        private readonly ISalesRepository _SalesRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetSalesHandler
        /// </summary>
        /// <param name="SalesRepository"></param>
        /// <param name="mapper"></param>
        public GetSalesHandler(ISalesRepository SalesRepository, IMapper mapper)
        {
            this._SalesRepository = SalesRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Handles the GetSalesCommand request
        /// </summary>
        /// <param name="command"> The GetSales command</param>
        /// <param name="cancellationToken">Cancelation token</param>
        /// <returns>The Sales details</returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<GetSalesResult> Handle(GetSalesCommand command, CancellationToken cancellationToken)
        {
            var validator = new GetSalesValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);
            
            var sales = await this._SalesRepository.GetByIdAsync(command.Id, cancellationToken);
            if (sales == null)
                throw new KeyNotFoundException($"Sales with ID {command.Id} not found");

            return _mapper.Map<GetSalesResult>(sales);
        }
    }
}
