using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CategoryDL : ICategoryDL
    {
        MyShopDbContext _myShopDbContext;
        public CategoryDL(MyShopDbContext myShopDbContext)
        {
            _myShopDbContext = myShopDbContext;
        }
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _myShopDbContext.Categories.ToListAsync();
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _myShopDbContext.Categories.AddAsync(category);
            await _myShopDbContext.SaveChangesAsync();
            return category;
        }
    }


}
