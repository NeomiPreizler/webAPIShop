using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
namespace BL
{
    public class RatingBL
    {
        IRatingDL _ratingDL;
        public RatingBL(IRatingDL ratingDL)
        {
            _ratingDL = ratingDL;
        }
        public async Task AddRating(Rating rate)
        {
            await _ratingDL.AddRating(rate);
        }
    }
}
