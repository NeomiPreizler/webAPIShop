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


        public async Task<User> GetbyIdAsync(int id)
        {
            return await _userDL.GetbyIdAsync(id);
        }


        public async Task<User> LogIn(User clientUser)
        {
            return await _userDL.LogIn(clientUser);
        }

        public async Task<User> AddNewUser(User user)
        {

            //if (await _userDL.isUserExist(user))
            //    return null;

            return await _userDL.AddNewUser(user);

        }


        public async Task UpdateUser(int id, User userToUpdate)
        {
            _userDL.UpdateUser(id, userToUpdate);
        }




    }
}
 