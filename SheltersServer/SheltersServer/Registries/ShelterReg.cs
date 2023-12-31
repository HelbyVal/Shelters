﻿using Microsoft.EntityFrameworkCore;
using SheltersServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Registries
{
    internal class ShelterReg : Registry<Shelter>
    {
        public ShelterReg() { } 

        public (List<Shelter>, int) GetShelters(int filtCity = -1,
                                         int filtShelter = -1,
                                         string filtOrgType = "",
                                         string filtName = "",
                                         string filtINN = "",
                                         string filtKPP = "",
                                         int lastId = 0,
                                         int count = 5)
        {
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<Shelter> dbSet = ContextDataBase.DB.Set<Shelter>();
                var shelters = dbSet.Where(x => true);
                if (filtCity != -1) shelters = shelters.Where(x => x.Id_City == filtCity);
                if (filtShelter != -1) shelters = shelters = shelters.Where(x => x.Id_Shelter == filtShelter);
                if (filtOrgType != "") shelters = shelters.Where(x => x.OrgType == filtOrgType);
                if (filtName != "") shelters = shelters.Where(x => x.Name == filtName);
                if (filtINN != "") shelters = shelters.Where(x => x.INN == filtINN);
                if (filtKPP != "") shelters = shelters.Where(x => x.KPP == filtKPP);

                int countPage = 0;
                if (shelters.Count() % count == 0)
                    countPage = shelters.Count() / count;
                else
                    countPage = shelters.Count() / count + 1;
                shelters = shelters.OrderBy(x => x.Id_Shelter)
                       .Where(x => x.Id_Shelter > lastId)
                       .Take(count);

                return (shelters.ToList(), countPage);
            }
        }
    }
}
