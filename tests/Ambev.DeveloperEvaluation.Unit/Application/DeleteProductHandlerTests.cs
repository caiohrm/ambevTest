using System;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;
using Ambev.DeveloperEvaluation.Application.Products.DeleteProducts;
using Ambev.DeveloperEvaluation.Application.Users.DeleteUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using Ambev.DeveloperEvaluation.Unit.Domain;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Contains unit tests for the <see cref="DeleteProductHandler"/> class.
    /// </summary>
    public class DeleteProductHandlerTests
	{
        private readonly IProductRepository _productRepository;
        private readonly DeleteProductHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteProductHandler"/> class.
        /// Sets up the test dependencies and retrievies fake data generators.
        /// </summary>
        public DeleteProductHandlerTests()
		{
            _productRepository = Substitute.For<IProductRepository>();
            _handler = new DeleteProductHandler(_productRepository);
        }

        /// <summary>
        /// Tests that a valid product delete request is handled successfully.
        /// </summary>
        [Fact(DisplayName = "Given valid product data When creating product Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = DeleteProductHandlerTestsData.GenerateValidCommand();
            

            var result = new DeleteProductResponse
            {
                Success = true,

            };
            
            _productRepository.DeleteAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>())
                .Returns(true);

            // When
            var DeleteProductResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            DeleteProductResult.Should().NotBeNull();
            //DeleteProductResult.Id.Should().Be(user.Id);
            await _productRepository.Received(1).DeleteAsync(Arg.Any<int>(), Arg.Any<CancellationToken>());
        }
    }
}

