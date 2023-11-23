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
    internal class KeepingReg : Registry<Keeping>
    {
        public KeepingReg() {}

        public Keeping FindLastForAnimal(int chipNum)
        {
           return dbSet.Include(x => x.Contract).Where(x => x.ChipNum == chipNum).Last();
        }
        public List<Keeping> FindAllUndilledInContract(int id_contr)
        {
            return dbSet.Where(x => x.Number == id_contr && x.IsFilled == false).ToList();
        } 
    }
}
