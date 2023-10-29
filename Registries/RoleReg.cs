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
        public RoleReg() 
        {
            db = new ContextDataBase();
            dbSet = db.Role;
        }
    }
}
