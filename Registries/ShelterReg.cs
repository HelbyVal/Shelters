using Shelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Registries
{
    internal class ShelterReg : Registry<Shelter>
    {
        public ShelterReg() { } 

        public List<Shelter> GetShelters(int cityFilt = -1, bool onlyActiveFilt = false, string orgTypeFilt ="")
        {
            var shelters = dbSet.Where(x => true);
            if (cityFilt != -1) shelters.Where(x => x.Id_Shelter == cityFilt);
            if (orgTypeFilt != "") shelters.Where(x => x.OrgType == orgTypeFilt);
            if (onlyActiveFilt) shelters.Where(x => x.IsActive == true);
            return shelters.ToList();
        }
    }
}
