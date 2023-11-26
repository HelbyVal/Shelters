using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Shelters.Models;
using Shelters.Registries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Services
{
    internal class CityService : Service
    {
        CityReg cityReg;
        public CityService() 
        {
            cityReg = new CityReg();
        }

        public bool AddCity(User user, string name, string subject)
        {
            try
            {;
                CheckRoles(user.Id_User, "Оператор ОМСУ");
                City city = new City() { Name = name, Subject = subject };
                cityReg.Add(city);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteCity(User user, int id_City)
        {
            try
            {
                CheckRoles(user.Id_User, "Оператор ОМСУ");
                City city = cityReg.Find(id_City);
                cityReg.Delete(city);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<City> GetCities(User user, string filtname, string subjFilt, bool activeFilt)
        {
            try
            {
                CheckRoles(user.Id_User, "Оператор ОМСУ", "Куратор ОМСУ");
                return cityReg.GetCities(filtname, subjFilt, activeFilt);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
