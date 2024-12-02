using System;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProducts;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
	public class DeleteProductHandlerTestsData
	{
        /// <summary>
        /// Configures the Faker to generate valid Product entities.
        /// The generated product will have valid:
        /// - Id
        /// </summary>
        private static readonly Faker<DeleteProductCommand> DeleteProductHandlerFaker = new Faker<DeleteProductCommand>()
            .RuleFor(u => u.Id, f => f.Random.Number(1, 999));

        /// <summary>
        /// Generates a valid Product entity with randomized data.
        /// The generated product will have all properties populated with valid values
        /// that meet the system's validation requirements.
        /// </summary>
        /// <returns>A valid product entity with randomly generated data.</returns>
        public static DeleteProductCommand GenerateValidCommand()
        {
            return DeleteProductHandlerFaker.Generate();
        }
    }
}

