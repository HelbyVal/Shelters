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

        public (List<Contract>, int) GetContracts(DateOnly filtDateStart,
                                           DateOnly filtDateEnd,       
                                           int filtNum = -1,
                                           int filtCostStart = int.MinValue,
                                           int filtCostEnd = int.MaxValue,
                                           int lastId = 0,
                                           bool isIncludeKeep = false,
                                           int filtShelter = -1,
                                           int count = 10)
        {
            var contrs = dbSet.Include(x => x.Keepings).Where(x => true);

            if (isIncludeKeep) contrs = contrs.Where(x => x.Id_Shelter == filtShelter);
            if (filtNum != -1) contrs = contrs.Where(x => x.Number == filtNum);
            if (filtShelter != -1) contrs = contrs.Where(x => x.Id_Shelter == filtShelter);
            contrs = contrs.Where(x => (x.CostPerDay >= filtCostStart) && (x.CostPerDay <= filtCostEnd));
            contrs = contrs.Where(x => (x.StartDate >= filtDateStart) && (x.EndDate <= filtDateEnd));

            int countPage = contrs.Count() / count;
            contrs.OrderBy(x => x.Number)
                   .Where(x => x.Number > lastId)
                   .Take(count);

            return (contrs.ToList(), countPage);
        }
    }
}
