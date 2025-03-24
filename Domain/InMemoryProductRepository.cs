using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public class InMemoryProductRepository : IProductRepository
{
    private readonly List<ProductData> _products;

    public InMemoryProductRepository()
    {
        var faker = new Bogus.Faker();

        _products = new List<ProductData>
        {
            new ProductData
            {
                Id = 1,
                Name = faker.Commerce.ProductName(),
                Price = faker.Random.Decimal(100, 500),
                Discount = 50,
                IsDiscounted = true,
                Category = "Electronics"
            },
            new ProductData
            {
                Id = 2,
                Name = faker.Commerce.ProductName(),
                Price = faker.Random.Decimal(10, 100),
                Discount = 0,
                IsDiscounted = false,
                Category = "Books"
            },
             new ProductData
            {
                Id = 3,
                Name = faker.Commerce.ProductName(),
                Price = faker.Random.Decimal(10, 100),
                Discount = 0,
                IsDiscounted = false,
                Category = "Furniture"
            },
              new ProductData
            {
                Id = 4,
                Name = faker.Commerce.ProductName(),
                Price = faker.Random.Decimal(10, 100),
                Discount = 0,
                IsDiscounted = false,
                Category = "TV"
            },
               new ProductData
            {
                Id = 5,
                Name = faker.Commerce.ProductName(),
                Price = faker.Random.Decimal(10, 100),
                Discount = 0,
                IsDiscounted = false,
                Category = "Mobile"
            }
        };
    }

    public ProductData GetProductById(int productId)
    {
        return _products.FirstOrDefault(p => p.Id == productId);
    }
}

