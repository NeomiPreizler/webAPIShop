using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ProductDL : IProductDL
    {
        MyShopDbContext _myShopDbContext;
        public ProductDL(MyShopDbContext myShopDbContext)
        {
            _myShopDbContext = myShopDbContext;
        }
        public async Task<List<Product>> Get()
        {

            return await _myShopDbContext.Products.Include(p=>p.Category).ToListAsync();
        }



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

