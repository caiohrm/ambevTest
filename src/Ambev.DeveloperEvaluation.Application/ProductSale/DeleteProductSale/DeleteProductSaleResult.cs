﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.ProductSale.DeleteProductSale
{
    /// <summary>
    /// Represents the response returned after sucessfully creating a new Sales
    /// </summary>
    /// <remarks>
    /// this reponse contains the unique identifier of the newly created Sales,
    /// which can be used for subsequent operations or reference
    /// </remarks>
    public class DeleteProductSaleResult
    {
        /// <summary>
        /// Creates a new instance of DeleteProductSaleResult
        /// </summary>
        /// <param name="sucess"></param>
        public DeleteProductSaleResult(bool sucess)
        {
            Sucess = sucess; 
        }
        /// <summary>
        /// Gets or sets if the sucess of the request
        /// </summary>
        /// <value> True or false</value>
        public bool Sucess { get; set; }
    }
}