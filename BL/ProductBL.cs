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
        public async Task<List<Product>> Get()
        {

            return await _productDL.Get();
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

