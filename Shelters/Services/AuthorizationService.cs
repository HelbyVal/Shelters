using Shelters.Models;
using Shelters.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Services
{
    internal class AuthorizationService
    {
        UserReg userReg;
        List<User> users;
        public AuthorizationService() 
        {
            userReg = new UserReg();
            users = new List<User>();
        }
        public User LogIn(string userName, string password)
        {   
            try
            {
                return userReg.CheckUser(userName, password);
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
