using Entities;

namespace DL
{
    public interface IProductDL
    {
        Task<IEnumerable<Product>> getProductsBySearch(IEnumerable<int>? categories, string? nameProduct, int? minPrice, int? maxPrice, string? orderBy = "name", string? direction = "desc");
        Task<Product> addProductAsync(Product product);
        //Task Put(int id, Product productToUpdate);
    }
}