using Entities;

namespace DL
{
    public interface ICategoryDL
    {
        Task<List<Category>> Get();
        Task<Category> Post(Category category);
    }
}