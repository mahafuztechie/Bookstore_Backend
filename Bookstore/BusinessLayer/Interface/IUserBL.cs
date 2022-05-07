using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
   public interface IUserBL
    {
        public UserModel UserRegister(UserModel user);

        public string UserLogin(string email, string password);
    }
}
