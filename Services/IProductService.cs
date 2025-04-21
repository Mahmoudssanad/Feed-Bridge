using FeedBridge_00.Models.Entities;

namespace FeedBridge_00.Services
{
    public interface IProductService
    {
        public void Delete(int id);

        public List<Product> GetAll();
        
        public Product GetById(int id);
        
        public void Insert(Product newProduct);

        public void Save();

        public void Update(Product newProduct, int id);
       
    }
}
