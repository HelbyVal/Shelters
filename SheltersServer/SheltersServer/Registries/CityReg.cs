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
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<City> dbSet = ContextDataBase.DB.Set<City>();
                var cities = dbSet.Where(x => true);
                return cities.ToList();
            }
        }
    }
}
