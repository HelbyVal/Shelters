using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SheltersServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Registries
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

        public List<Role> GetRoles() 
        {
            return dbSet.Where(x => true).ToList();
        }
    }
}
