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
    internal class CityReg : Registry<City>
    {
        public CityReg() {}

        public List<City> GetCities(string nameFilt = "", string subjFilt = "", bool onlyActiveFilt = false)
        {
            var cities = dbSet.Where(x => true);
            if (nameFilt != "") cities.Where(x => x.Name == nameFilt);
            if (subjFilt != "") cities.Where(x => x.Subject == subjFilt);
            return cities.ToList();
        }
    }
}
