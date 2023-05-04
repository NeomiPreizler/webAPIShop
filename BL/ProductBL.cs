using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
namespace BL
{

    public class ProductBL : IProductBL
    {
        IProductDL _productDL;


        public ProductBL(IProductDL productDL)
        {
            _productDL = productDL;

        }
        public async Task<IEnumerable<Product>> Get(IEnumerable<string>? categories, string? nameProduct, int? minPrice, int? maxPrice, string? orderBy = "name", string? direction = "desc")
        {

            return await _productDL.Get(categories,nameProduct, minPrice, maxPrice, orderBy, direction);
        }
        public async Task<Product> Post(Product product)
        {

            return await _productDL.Post(product);

        }

        public async Task Put(int id, Product productToUpdate)
        {
            _productDL.Put(id, productToUpdate);

        }

    }
}

