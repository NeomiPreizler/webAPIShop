using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DL
{
    public class ProductDL : IProductDL
    {
        MyShopDbContext _myShopDbContext;
        public ProductDL(MyShopDbContext myShopDbContext)
        {
            _myShopDbContext = myShopDbContext;
        }
      
 
        public async Task<IEnumerable<Product>> getProductsBySearch(IEnumerable<int>? categories, string? nameProduct, int? minPrice, int? maxPrice, string? orderBy = "name", string? direction = "desc")
        {
            return  await _myShopDbContext.Products.Include(p => p.Category).Where(p =>
                    (categories.Count() == 0 ? true : categories.Contains(p.Category.CategoryId)) &&
                    (nameProduct == null || p.ProductName.Contains(nameProduct)) &&
                    (minPrice == null || p.Price >= minPrice) &&
                    (maxPrice == null || p.Price <= maxPrice))
                    .OrderBy(p => p.Price).ToListAsync();
        }
       
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _myShopDbContext.Products.FindAsync(id);
        }

        public async Task<Product> addProductAsync(Product product)
        {
            await _myShopDbContext.Products.AddAsync(product);
            await _myShopDbContext.SaveChangesAsync();
            return product;

        }

        //public async Task Put(int id, Product productToUpdate)
        //{

        //    Product product = await _myShopDbContext.Products.FindAsync(id);
        //    if (product != null)
        //    {
        //        _myShopDbContext.Products.Update(productToUpdate);

        //        await _myShopDbContext.SaveChangesAsync();
        //    }

        //}


    }

}

