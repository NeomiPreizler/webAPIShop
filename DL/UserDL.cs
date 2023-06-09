﻿using Entities;
using System.Runtime.InteropServices;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class UserDL:IUserDL
    {

        static private string _filePath = "M:\\webApi\\1myProjectefrat3\\DL\\Data.txt";

        MyShopDbContext _myShopDbContext;
        public UserDL(MyShopDbContext myShopDbContext)
        {
            _myShopDbContext = myShopDbContext;
        }


        public async Task<User> GetbyIdAsync(int id)
        {
            User user = await _myShopDbContext.Users.Where(u => u.UserId == id).Include(u => u.Orders).FirstOrDefaultAsync();
            return user != null ? user : null;

        }

       
        public async Task<User> LogIn(User clientUser)
        {

            List<User> user = await _myShopDbContext.Users.Where(user => user.Email == clientUser.Email && user.Password == clientUser.Password).ToListAsync();
            return user.Count() > 0 ? user[0] : null;

        }
     
        public async Task<User> AddNewUser(User user)
        {   
          
            await _myShopDbContext.Users.AddAsync(user);
            await _myShopDbContext.SaveChangesAsync();
            return user;
        }
        public async Task<bool> isUserExist(User user)
        {

            List<User> currentUserIn = await  _myShopDbContext.Users.Where( u => user.Email == u.Email).ToListAsync();
            return (currentUserIn[0] != null);
 
        }


        public async Task UpdateUser(int id, User userToUpdate)
        {

            //User user = await _myShopDbContext.Users.FindAsync(id);
            //if (user != null)
            //{
                _myShopDbContext.Users.Update(userToUpdate);
               //_myShopDbContext.Entry(userToUpdate).CurrentValues.SetValues(userToUpdate);
                await _myShopDbContext.SaveChangesAsync();
            //}

        }


    }
}