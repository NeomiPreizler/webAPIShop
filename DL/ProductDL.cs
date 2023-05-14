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
      
        //public async Task<List<Product>> Get(int[]? categories, string? nameProduct, int? minPrice, int? maxPrice,  string? orderBy = "name", string? direction = "desc")//(int? minPrice, int? maxPrice, IEnumerable<string>? categories, string? nameProduct)
        //{
            //var qurey = _myShopDbContext.Products.Where(product => (nameProduct == null ? (true) : (product.Description.Contains(nameProduct)))
            // && ((minPrice == null) ? (true) : (product.Price >= minPrice)).ToListAsync();
            // && ((categories.Length == 0) ? (true) : (product.Category.Contains(categories)))
            // && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))).OrderBy(product => orderBy).Include(p => p.CategoryNavigation).ToArray();
            //Console.WriteLine(qurey);

            //List<Product> products = qurey.ToListAsync();
            //return products;
            //List<Product> products = await _myShopDbContext.Products.Include(p => p.Category).Where(p =>
            //        (categories.Count() == 0 ? true : !categories.Contains(p.Category.CategoryName)) &&
            //        (nameProduct == null || p.ProductName.Contains(nameProduct)) &&
            //        (minPrice == null || p.Price >= minPrice) &&
            //        (maxPrice == null || p.Price <= maxPrice))
            //        .OrderBy(p => p.Price).ToListAsync();
            //return products;
            public async Task<IEnumerable<Product>> Get(IEnumerable<int>? categories, string? nameProduct, int? minPrice, int? maxPrice, string? orderBy = "name", string? direction = "desc")
            {
                return await _myShopDbContext.Products.Include(p => p.Category).Where(p =>
                    (categories.Count() == 0 ? true : categories.Contains(p.Category.CategoryId)) &&
                    (nameProduct == null || p.ProductName.Contains(nameProduct)) &&
                    (minPrice == null || p.Price >= minPrice) &&
                    (maxPrice == null || p.Price <= maxPrice))
                    .OrderBy(p => p.Price).ToListAsync();
            }
        //}



        public async Task<Product> Post(Product product)
        {
            await _myShopDbContext.Products.AddAsync(product);
            await _myShopDbContext.SaveChangesAsync();
            return product;

        }

        public async Task Put(int id, Product productToUpdate)
        {

            Product product = await _myShopDbContext.Products.FindAsync(id);
            if (product != null)
            {
                _myShopDbContext.Products.Update(productToUpdate);

                await _myShopDbContext.SaveChangesAsync();
            }

        }


    }

}

