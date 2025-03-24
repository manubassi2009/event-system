using Domain;
using Domain.Interface;
using FluentAssertions;

namespace TestProject
{
    public class ProductFactoryTests
    {
        private readonly IProductFactory _productFactory;
        private readonly InMemoryProductRepository _repository;

        public ProductFactoryTests()
        {
            _repository = new InMemoryProductRepository();
            _productFactory = new ProductFactory(_repository);
        }
        
        [Fact]
        public void CreateProduct_ShouldReturnDiscountedProduct_WhenProductIsDiscounted()
        {
            // Arrange
            var productId = 1;

            // Act
            var product = _productFactory.CreateProduct(productId);

            // Assert
            product.Should().BeOfType<DiscountedProduct>();
            ((DiscountedProduct)product).Discount.Should().BeGreaterThan(0);
        }
        [Fact]
        public void CreateProduct_ShouldReturnRegularProduct_WhenProductIsNotDiscounted()
        {
            // Arrange
            var productId = 2;

            // Act
            var product = _productFactory.CreateProduct(productId);

            // Assert
            product.Should().BeOfType<RegularProduct>();
            ((RegularProduct)product).Category.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public void CreateProduct_ShouldThrowException_WhenProductDoesNotExist()
        {
            // Arrange
            var invalidProductId = 99; // Non-existent product ID

            // Act
            Action act = () => _productFactory.CreateProduct(invalidProductId);

            // Assert
            act.Should().Throw<ArgumentException>()
               .WithMessage("Product with ID 99 not found.");
        }
    }
}
