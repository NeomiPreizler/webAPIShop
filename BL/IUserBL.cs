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
        Task<User> Get(int id);
        Task<User> LogIn(User clientUser);
        Task<User> Post(User user);
        Task Put(int id, User userToUpdate);


    }
}
