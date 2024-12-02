using System;
using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class GetProductHandlerTestsData
	{
        /// <summary>
        /// Configures the Faker to generate valid Product command.
        /// The generated class will have valid:
        /// - Id 
        /// </summary>
        private static readonly Faker<GetProductCommand> getProductHandlerFaker = new Faker<GetProductCommand>()
        .RuleFor(u => u.Id, f => 1);

        /// <summary>
        /// Generates a valid product command with randomized data.
        /// The generated product command will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid Product command with randomly generated data.</returns>
        public static GetProductCommand GenerateValidCommand()
        {
            return getProductHandlerFaker.Generate();
        }
    }
}

