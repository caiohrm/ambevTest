using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSalesValues
{
    /// <summary>
    /// Profile for mapping between User entity and UpdateSalesValuesResponse
    /// </summary>
    public class UpdateSalesValuesProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateSalesValues operation
        /// </summary>
        public UpdateSalesValuesProfile()
        {
            CreateMap<UpdateSalesValuesCommand, Ambev.DeveloperEvaluation.Domain.Entities.Sales>();
            CreateMap<Ambev.DeveloperEvaluation.Domain.Entities.Sales, UpdateSalesValuesResult>();
        }
    }
}
