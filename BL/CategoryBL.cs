using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryBL : ICategoryBL
    {
        ICategoryDL _categoryDL;
        public CategoryBL(ICategoryDL categoryDL)
        {
            _categoryDL = categoryDL;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryDL.GetAllCategoriesAsync();
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            return await _categoryDL.AddCategoryAsync(category);
        }
    }
}
