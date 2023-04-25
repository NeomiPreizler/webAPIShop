using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IUserDL
    {
        Task<User> Get(int id);
        Task<User> LogIn(Entities.User clientUser);
        Task<User> Post(Entities.User user);
        Task<bool> isUserExist(Entities.User user);
        Task Put(int id, Entities.User userToUpdate);
    }
}
