using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Shelters.Models;
using Shelters.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Services
{
    internal class ShelterService : ProtectedService
    {
        ShelterReg shelterReg;
        public ShelterService() 
        {
            shelterReg = new ShelterReg();
        }

        public bool CreateShelter(User user, string inn, string kpp, string orgType, int id_City)
        {
            try
            {
                CheckRoles(user.Id_User, "Оператор ОМСУ");
                Shelter shelt = new Shelter()
                {
                    INN = inn,
                    KPP = kpp,
                    OrgType = orgType,
                    Id_City = id_City
                };
                shelterReg.Add(shelt);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeactivateShelter(User user, int id_shelter) 
        {
            try
            {
                CheckRoles(user.Id_User, "Оператор ОМСУ");
                Shelter shelter = shelterReg.Find(id_shelter);
                shelter.IsActive = false;
                shelterReg.Update(shelter);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Shelter> GetShelters(User user, int cityFilt, bool OnlyActiveFilt, string orgTypeFilt)
        {
            try
            {
                CheckRoles(user.Id_User, "Оператор ОМСУ", "Куратор ОМСУ");
                return shelterReg.GetShelters(cityFilt, OnlyActiveFilt, orgTypeFilt);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
