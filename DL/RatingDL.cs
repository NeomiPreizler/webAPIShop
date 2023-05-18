using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace DL
{
    public class RatingDL : IRatingDL
    {
        MyShopDbContext _myShopDbContext;
        public RatingDL(MyShopDbContext myShopDbContext)
        {
            _myShopDbContext = myShopDbContext;
        }
        public async Task AddRating(Rating rate)
        {
            await _myShopDbContext.Rating.AddAsync(rate);
            await _myShopDbContext.SaveChangesAsync();
        }
    }
}
