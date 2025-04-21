using FeedBridge_00.Models;
using FeedBridge_00.Models.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FeedBridge_00.Repository
{
    // All Bussines logic of Products in this repo
    public class ProductRepository : IProductRepository
    {
        AppDbContext _context; //= new AppDbContext();

        // ProductController في AppDbContext لل Inject عملت 
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            if(product != null)
            {
                _context.Products.Remove(product);
            }

        }

        public List<Product> GetAll()
        {
            var allProducts = _context.Products.ToList();
            return allProducts;
        }

        public Product GetById(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
                return product;
        }

        public void Insert(Product newProduct)
        {
            _context.Products.Add(newProduct);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product newProduct, int id) 
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if(product != null)
            {
                if(newProduct.Name != null)
                {
                    product.Name = newProduct.Name;
                    product.Status = newProduct.Status;
                    product.Quantity = newProduct.Quantity;
                }
            }
        }

    }
}
