using Microsoft.EntityFrameworkCore;
using Shelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Registries
{
    internal class ContractReg : Registry<Contract>
    {
        public ContractReg() 
        {}
        public Contract FindLastShelterContract(int id_shelter, bool isIncludeKeep = false) 
        {
            Contract contr = new Contract();
            if (isIncludeKeep)
            {
                contr = dbSet.Include(x => x.Keepings).Where(ct => ct.Id_Shelter == id_shelter).Last();
            }
            else
            {
                contr = dbSet.Where(ct => ct.Id_Shelter == id_shelter).Last();
            }
            if (contr == null)
            {
                throw new Exception("Для этого прюта не созданы контракты");
            }
            return contr;
        }

        public List<Contract> GetContracts(int filtShelter = -1, bool isIncludeKeep = false)
        {
            if (isIncludeKeep) return dbSet.Include(x => x.Keepings).Where(x => x.Id_Shelter == filtShelter).ToList();
            return dbSet.Where(x => x.Id_Shelter == filtShelter).ToList();
        }
    }
}
