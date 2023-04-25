using Entities;

namespace DL
{
    public interface IProductDL
    {
        Task<List<Product>> Get();
        Task<Product> Post(Product product);
        Task Put(int id, Product productToUpdate);
    }
}