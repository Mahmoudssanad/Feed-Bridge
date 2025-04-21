using FeedBridge_00.Models.Entities;
using FeedBridge_00.Repository;
using Microsoft.EntityFrameworkCore;

namespace FeedBridge_00.Services
{
    // Contain => all Business logic of product
    public class ProductService : IProductService
    {
        IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public List<Product> GetAll()
        {
            var allProducts = _productRepository.GetAll();
            return allProducts;
        }

        public Product GetById(int id)
        {
            var product = _productRepository.GetById(id);
            return product;
        }

        public void Insert(Product newProduct)
        {
            _productRepository.Insert(newProduct);
        }

        public void Save()
        {
            _productRepository.Save();
        }

        public void Update(Product newProduct, int id)
        {
            var product = _productRepository.GetById(id);
            if (product != null)
            {
                _productRepository.Update(newProduct, id);
            }
        }
    }
}
