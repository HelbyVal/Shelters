using Microsoft.EntityFrameworkCore;
using Shelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Registries
{
    internal class UserRoleReg : Registry<UserRole>
    {
        public UserRoleReg() { }

        public List<UserRole> FindAllByUser(int id_user)
        {
            var entities = dbSet.Include(x => x.Role).Where(x => x.Id_User == id_user).ToList();
            return entities;
        }
        public void Delete(int id_role, int id_user)
        {
            List<UserRole> userRoles = dbSet.Where(x => x.Id_Role == id_role).ToList();
            foreach (UserRole userRole in userRoles) 
            {
                if (userRole.Id_User == id_user) this.Delete(this.Find(userRole.Id_UserRole));
            }
            
        }
    }
}
