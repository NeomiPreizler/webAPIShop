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
        public async Task<List<Category>> Get()
        {
            return await _categoryDL.Get();
        }

        public async Task<Category> Post(Category category)
        {
            return await _categoryDL.Post(category);
        }
    }
}
