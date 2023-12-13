using SheltersServer.Models;
using SheltersServer.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;

namespace SheltersServer.Services
{
    internal class AuthorizationService
    {
        UserReg userReg;
        UserRoleReg roleReg;
        public AuthorizationService() 
        {
            userReg = new UserReg();
            roleReg = new UserRoleReg();
        }
        public User LogIn(string userName, string password)
        {   
            return userReg.CheckUser(userName, password);
        }

        public List<string> GetRoles(int id_user)
        {
            return roleReg.FindAllByUser(id_user)
                .Select(x => x.Role)
                .Select(x => x.Name)
                .ToList();
        }
    }
}
