using Entities;

namespace DL
{
    public interface IProductDL
    {
        Task<IEnumerable<Product>> Get(IEnumerable<string>? categories, string? nameProduct, int? minPrice, int? maxPrice, string? orderBy = "name", string? direction = "desc");
        Task<Product> Post(Product product);
        Task Put(int id, Product productToUpdate);
    }
}