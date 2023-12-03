using SheltersServer.Models;
using SheltersServer.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Services
{
    internal class RoleService : Service
    {
        RoleReg roleReg;
        public RoleService() 
        {
            roleReg = new RoleReg();
        }

        public List<Role> GetRoles(User user)
        {
            try
            {
                return roleReg.GetRoles();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
