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
    }
}
