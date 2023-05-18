using DL;
using Entities;
using System.Text.Json;
//import
//{ zxcvbn, zxcvbnOptions }
//from '@zxcvbn-ts/core'
//import zxcvbnCommonPackage from '@zxcvbn-ts/language-common'
//import zxcvbnEnPackage from '@zxcvbn-ts/language-en'
namespace BL
{

    public class UserBL:IUserBL
    {
        IUserDL _userDL ;
        public UserBL(IUserDL userDL)
        {
            _userDL = userDL;
        }


        public async Task<User> Get(int id)
        {
            return await _userDL.Get(id);
        }


        public async Task<User> LogIn(User clientUser)
        {
            return await _userDL.LogIn(clientUser);
        }

        public async Task<User> Post(User user)
        {

            //if (await _userDL.isUserExist(user))
            //    return null;

            return await _userDL.Post(user);

        }


        public async Task Put(int id, User userToUpdate)
        {
            _userDL.Put(id, userToUpdate);
        }

        // DELETE api/<LoginController>/5

        public void Delete(int id)
        {



        }

       
    }
}
 