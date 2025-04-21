using FeedBridge_00.Models.Entities;

namespace FeedBridge_00.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        void Update(Product newProduct, int id);
        void Insert(Product newProduct);
        void Delete(int id);

        Product GetById(int id);
        void Save();
    }
}
