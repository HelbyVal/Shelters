using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Shelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Registries
{
    internal class RoleReg : Registry<Role>
    {
        public RoleReg() {}
        public Role FindWithRole(string name)
        {
            var entity = dbSet.Include(x => x.UserRole).Where(x => x.Name == name).Single();
            if (entity == null)
                throw new Exception($"Роль не найдена!");
            return entity;
        }
    }
}
