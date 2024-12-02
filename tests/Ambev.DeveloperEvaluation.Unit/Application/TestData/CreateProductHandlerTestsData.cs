using System;
using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    /// <summary>
    /// Provides methods for generating test data using the Bogus library.
    /// This class centralizes all test data generation to ensure consistency
    /// across test cases and provide both valid and invalid data scenarios.
    /// </summary>
    public static class CreateProductHandlerTestsData
	{
        /// <summary>
        /// Configures the Faker to generate valid Product entities.
        /// The generated product will have valid:
        /// - Title 
        /// - Price
        /// </summary>
        private static readonly Faker<CreateProductCommand> createProductHandlerFaker = new Faker<CreateProductCommand>()
            .RuleFor(u => u.Title, f => "Beer")
            .RuleFor(u => u.Price, f => f.Random.Number(1, 999));

        /// <summary>
        /// Generates a valid Product entity with randomized data.
        /// The generated product will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid product entity with randomly generated data.</returns>
        public static CreateProductCommand GenerateValidCommand()
        {
            return createProductHandlerFaker.Generate();
        }
    }
}

