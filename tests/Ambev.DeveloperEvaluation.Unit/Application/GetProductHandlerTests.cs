using System;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    /// <summary>
    /// Contains unit tests for the <see cref="GetProductHandler"/> class.
    /// </summary>
    public class GetProductHandlerTests
	{
        private readonly IProductRepository _productRepository;
        private readonly GetProductHandler _handler;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetProductHandler"/> class.
        /// Sets up the test dependencies and retrievies fake data generators.
        /// </summary>
        public GetProductHandlerTests()
		{
            _productRepository = Substitute.For<IProductRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetProductHandler(_productRepository,_mapper);
        }

        /// <summary>
        /// Tests that a valid product get request is handled successfully.
        /// </summary>
        [Fact(DisplayName = "Given valid product data When sending valid Id Then returns success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Given
            var command = GetProductHandlerTestsData.GenerateValidCommand();


            var result = new GetProductResult
            {
                Id = 1,
                Title = "Beer",
                Price = 10

            };

            var product = new Product()
            {
                Id=1,
                Title = "Beer",
                Price = 10
            };
            _mapper.Map<GetProductResult>(product).Returns(result);

            _productRepository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
                .Returns(product);

            // When
            var getProductResult = await _handler.Handle(command, CancellationToken.None);

            // Then
            GetProductResult.Should().NotBeNull();
            GetProductResult.Id.Should().Be(product.Id);
            await _productRepository.Received(1).GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>());
        }
    }
}

