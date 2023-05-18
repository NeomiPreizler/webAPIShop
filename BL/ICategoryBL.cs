using Entities;

namespace BL
{
    public interface ICategoryBL
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> AddCategoryAsync(Category category);
    }
}