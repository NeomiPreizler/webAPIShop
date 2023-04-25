using Entities;

namespace BL
{
    public interface ICategoryBL
    {
        Task<List<Category>> Get();
        Task<Category> Post(Category category);
    }
}