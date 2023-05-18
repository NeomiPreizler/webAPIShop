using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IUserBL
    {
        Task<User> GetbyIdAsync(int id);
        Task<User> LogIn(User clientUser);
        Task<User> AddNewUser(User user);
        Task UpdateUser(int id, User userToUpdate);


    }
}
