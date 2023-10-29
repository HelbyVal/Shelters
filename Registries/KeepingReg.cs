using Shelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Registries
{
    internal class KeepingReg : Registry<Keeping>
    {
        public KeepingReg() 
        {
            db = new ContextDataBase();
            dbSet = db.Keeping;
        }
    }
}
