using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public class ProductFactory : IProductFactory
{
    private readonly IProductRepository _productRepository;
    private readonly IList<IProductObserver> _observers;
    public ProductFactory(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public void RegisterObserver(IProductObserver observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(IProductObserver observer)
    {
        _observers.Remove(observer);
    }

    private void NotifyObservers(Product product)
    {
        foreach (var observer in _observers)
        {
            observer.OnProductCreator(product);
        }
    }

    public Product CreateProduct(int productId)
    {
        var productData = _productRepository.GetProductById(productId);

        if (productData == null)
        {
            throw new ArgumentException($"Product with ID {productId} not found.");
        }

        Product product = productData.IsDiscounted
            ? new DiscountedProduct
            {
                Name = productData.Name,
                Price = productData.Price,
                Discount = productData.Discount
            }
            : new RegularProduct
            {
                Name = productData.Name,
                Price = productData.Price,
                Category = productData.Category
            };

        NotifyObservers(product);

        return product;
    }
}
