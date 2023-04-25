using Entities;

namespace BL
{
    public interface IProductBL
    {
        Task<List<Product>> Get();
        Task<Product> Post(Product product);
        Task Put(int id, Product productToUpdate);

    }
}