using System;
using Ambev.DeveloperEvaluation.Application.Products.CreateProducts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.ORM.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using Ambev.DeveloperEvaluation.Unit.Domain;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Contains unit tests for the <see cref="CreateProductHandler"/> class.
    /// </summary>
    public class CreateProductHandlerTests
	{
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly CreateProductHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateProductHandler"/> class.
        /// Sets up the test dependencies and creates fake data generators.
        /// </summary>
        public CreateProductHandlerTests()
		{
            _productRepository = Substitute.For<IProductRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateProductHandler(_productRepository, _mapper);
        }

        /// <summary>
        /// Tests that a valid product creation request is handled successfully.
        /// </summary>
        [Fact(DisplayName = "Given valid product data When creating product Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = CreateProductHandlerTestsData.GenerateValidCommand();
            var product = new Product
            {
                Title= command.Title,
                Price = command.Price
            };

            var result = new CreateProductResult
            {
                Id = product.Id,

            };


            _mapper.Map<Product>(command).Returns(product);
            _mapper.Map<CreateProductResult>(product).Returns(result);

            _productRepository.CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>())
                .Returns(product);

            // When
            var createProductResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            createProductResult.Should().NotBeNull();
            //createProductResult.Id.Should().Be(user.Id);
            await _productRepository.Received(1).CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>());
        }
    }
}

