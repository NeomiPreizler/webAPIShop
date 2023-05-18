using Entities;

namespace DL
{
   public interface IRatingDL
    {
        Task AddRating(Rating rate);
    }
}