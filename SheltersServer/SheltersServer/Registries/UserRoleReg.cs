using Microsoft.EntityFrameworkCore;
using SheltersServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Registries
{
    internal class UserRoleReg : Registry<UserRole>
    {
        public UserRoleReg() { }

        public List<UserRole> FindAllByUser(int id_user)
        {
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<UserRole> dbSet = ContextDataBase.DB.Set<UserRole>();
                var entities = dbSet.Include(x => x.Role).Where(x => x.Id_User == id_user).ToList();
                return entities;
            }
        }
        public void Delete(int id_role, int id_user)
        {
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<UserRole> dbSet = ContextDataBase.DB.Set<UserRole>();
                List<UserRole> userRoles = dbSet.Where(x => x.Id_Role == id_role).ToList();
                foreach (UserRole userRole in userRoles)
                {
                    if (userRole.Id_User == id_user) this.Delete(this.Find(userRole.Id_UserRole));
                }
            }
        }
    }
}
