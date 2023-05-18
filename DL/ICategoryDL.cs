using Entities;

namespace DL
{
    public interface ICategoryDL
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> AddCategoryAsync(Category category);
    }
}