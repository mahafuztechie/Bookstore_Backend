using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
   public class UserBL: IUserBL
    {
        private readonly IUserRL userRL;

   
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }

        public UserModel UserRegister(UserModel user)
        {
            try
            {
                return this.userRL.UserRegister(user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string UserLogin(string email, string password)
        {
            try
            {
                return this.userRL.UserLogin(email, password);
            }
            catch (Exception)
            {
                throw;
            }
        }

      
    }
}
