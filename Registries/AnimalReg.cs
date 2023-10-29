using Shelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Registries
{
    internal class AnimalReg : Registry<Animal>
    {
        public AnimalReg() 
        {
            db = new ContextDataBase();
            dbSet = db.Animal;
        }
    }
}
