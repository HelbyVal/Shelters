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
        {
            db = new ContextDataBase();
            dbSet = db.Contract;
        }
        public Contract FindLastShelterContract (int id_shelter) 
        {
            Contract contr = dbSet.Where(ct => ct.Id_Shelter == id_shelter).Last();
            if (contr == null)
            {
                throw new Exception("Не найден контракт");
            }
            return contr;
        }
    }
}
