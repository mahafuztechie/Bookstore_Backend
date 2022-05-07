using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
   public interface IUserRL
    {
        public UserModel UserRegister(UserModel user);
        public string UserLogin(string email, string password);
    }
}
