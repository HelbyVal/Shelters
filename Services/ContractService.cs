using Shelters.Models;
using Shelters.Registries;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Services
{
    internal class ContractService : ProtectedService
    {
        ContractReg contrReg;
        KeepingReg keepingReg;
        public ContractService() 
        {
            contrReg = new ContractReg();
        }

        public bool CreateNewContract(int id_user, string password, double costPerDay, DateOnly startDate, DateOnly endDate, int id_Shelter)
        {
            try
            {
                User user = TakeUser(id_user, password);
                CheckRoles(id_user, "Оператор ОМСУ");
                var oldContr = contrReg.FindLastShelterContract(id_Shelter, true);
                if (oldContr == null)
                {
                    Contract newContr = new Contract(costPerDay, startDate, endDate, id_Shelter);
                }
                else
                {
                    if (oldContr.EndDate > startDate && oldContr.StartDate < startDate)
                    {
                        Contract newContr = new Contract(costPerDay, startDate, endDate, id_Shelter);
                        contrReg.Add(newContr);
                        var oldKeeps = keepingReg.FindAllUndilledInContract(oldContr.Number);
                        foreach (var item in oldKeeps)
                        {
                            item.CreateCopy(newContr);
                            keepingReg.Add(item);
                        }
                    }
                    else throw new Exception("Нельзя создать новый контракт с выбранными датами");
                }
                return false;
            }
            catch (Exception ex) 
            {
                return true;
            }
        }
        public List<Contract> GetContracts(int id_user, string password, int id_shelter, bool allShelters = true)
        {
            try
            {
                User user = TakeUser(id_user, password);
                if (allShelters == true)
                {
                    CheckRoles(id_user, "Оператор ОМСУ", "Куратор ОМСУ");
                    return contrReg.GetContracts(id_shelter);
                }
                else
                {
                    CheckRoles(id_user, "Оператор приюта", "Куратор приюта");
                    CheckShelter(user, id_shelter);
                    return contrReg.GetContracts(id_shelter);
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public bool DeleteContract(int id_user, string password, int numberContr)
        {
            try
            {
                User user = TakeUser(id_user, password);
                CheckRoles(id_user,"Оператор ОМСУ");
                contrReg.Delete(contrReg.Find(numberContr));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
