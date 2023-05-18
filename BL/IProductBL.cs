using Entities;

namespace BL
{
    public interface IProductBL
    {
        Task<IEnumerable<Product>> getProductsBySearch(IEnumerable<int>? categories, string? nameProduct, int? minPrice, int? maxPrice, string? orderBy = "name", string? direction = "desc");

        Task<Product> GetProductByIdAsync(int id);

        Task<Product> addProductAsync(Product product);

        //Task Put(int id, Product productToUpdate);

    }
}