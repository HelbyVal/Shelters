using Microsoft.EntityFrameworkCore;
using SheltersServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Registries
{
    internal class ContractReg : Registry<Contract>
    {
        public ContractReg() 
        {}
        public Contract FindLastShelterContract(int id_shelter, bool isIncludeKeep = false)
        {
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<Contract> dbSet = ContextDataBase.DB.Set<Contract>();
                Contract contr = new Contract();
                if (isIncludeKeep)
                {
                    contr = dbSet.Include(x => x.Keepings).Where(ct => ct.Id_Shelter == id_shelter).OrderBy(ct => ct.Number).LastOrDefault();
                }
                else
                {
                    contr = dbSet.Where(ct => ct.Id_Shelter == id_shelter).Last();
                }
                return contr;
            }
        }

        public List<Contract> GetContracts(int filtShelter = -1, bool isIncludeKeep = false)
        {
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<Contract> dbSet = ContextDataBase.DB.Set<Contract>();
                if (isIncludeKeep) return dbSet.Include(x => x.Keepings).Where(x => x.Id_Shelter == filtShelter).ToList();
                var res = dbSet.Where(x => x.Id_Shelter == filtShelter).ToList();
                return res;
            }
        }

        public (List<Contract>, int) GetContracts(DateOnly filtDateStart,
                                           DateOnly filtDateEnd,
                                           int filtNum = -1,
                                           double filtCostStart = 0,
                                           double filtCostEnd = int.MaxValue,
                                           int lastId = 0,
                                           bool isIncludeKeep = false,
                                           int filtShelter = -1,
                                           int count = 5)
        {
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<Contract> dbSet = ContextDataBase.DB.Set<Contract>();
                var contrs = dbSet.Include(x => x.Keepings).Where(x => true);

                if (filtNum != -1) contrs = contrs.Where(x => x.Number == filtNum);
                if (filtShelter != -1) contrs = contrs.Where(x => x.Id_Shelter == filtShelter);
                contrs = contrs.Where(x => (x.CostPerDay >= filtCostStart) && (x.CostPerDay <= filtCostEnd));
                contrs = contrs.Where(x => (x.StartDate >= filtDateStart) && (x.EndDate <= filtDateEnd));

                int countPage = 0;
                if (contrs.Count() % count == 0)
                {
                    countPage = contrs.Count() / count;
                }
                else
                {
                    countPage = contrs.Count() / count + 1;
                }
                contrs = contrs.OrderBy(x => x.Number)
                       .Where(x => x.Number > lastId)
                       .Take(count);

                return (contrs.ToList(), countPage);
            }
        }
    }
}
