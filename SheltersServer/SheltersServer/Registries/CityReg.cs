using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using SheltersServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Registries
{
    internal class CityReg : Registry<City>
    {
        public CityReg() {}

        public List<City> GetCities()
        {
            var cities = dbSet.Where(x => true);
            return cities.ToList();
        }
    }
}
