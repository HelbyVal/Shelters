using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SheltersServer.Models;
using SheltersServer.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Services
{
    internal class ShelterService : Service
    {
        ShelterReg shelterReg;
        public ShelterService() 
        {
            shelterReg = new ShelterReg();
        }

        public bool CreateShelter(User user, string name, string inn, string kpp, string orgType, int id_City)
        {
            try
            {
                CheckRoles(user.Id_User, "Оператор ОМСУ");
                Shelter shelt = new Shelter()
                {
                    Name = name,
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
