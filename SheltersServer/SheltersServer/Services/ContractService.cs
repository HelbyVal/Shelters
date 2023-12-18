using SheltersServer.Models;
using SheltersServer.Registries;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Services
{
    internal class ContractService : Service
    {
        ContractReg contrReg;
        public ContractService() 
        {
            contrReg = new ContractReg();
        }

        public bool CreateNewContract(User user, double costPerDay, DateOnly startDate, DateOnly endDate, int id_Shelter)
        {
            try
            {
                CheckRoles(user.Id_User, "Оператор ОМСУ");

                if (startDate < endDate)
                {
                    Contract newContr = new Contract(costPerDay, startDate, endDate, id_Shelter);
                    contrReg.Add(newContr);
                }
                else
                {
                    throw new Exception("Нельзя создать новый контракт с выбранными датами");
                }
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
        public (List<Contract>, int) GetContracts(User user,
                                            int id_shelter,
                                            int filtNum,
                                            double filtCostStart,
                                            double filtCostEnd,
                                            DateOnly filtDateStart,
                                            DateOnly filtDateEnd,
                                            int lastId,
                                            bool includeKeep,
                                            bool allShelters = true)
        {
            try
            {
                if (allShelters == true)
                {
                    CheckRoles(user.Id_User, "Оператор ОМСУ", "Куратор ОМСУ");
                    return contrReg.GetContracts(filtDateStart, filtDateEnd, filtNum, filtCostStart, filtCostEnd, lastId, includeKeep);
                }
                else
                {
                    CheckRoles(user.Id_User, "Оператор приюта", "Куратор приюта");
                    CheckShelter(user, id_shelter);
                    return contrReg.GetContracts(filtDateStart, filtDateEnd, filtNum, filtCostStart, filtCostEnd, lastId, includeKeep, id_shelter);
                }
            }
            catch (Exception e)
            {
                return (new List<Contract>(), 0);
            }
        }
        public bool DeleteContract(User user, int numberContr)
        {
            try
            {
                CheckRoles(user.Id_User,"Оператор ОМСУ");
                contrReg.Delete(contrReg.Find(numberContr));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateContract(User user, Contract contract)
        {
            try
            {
                CheckRoles(user.Id_User, "Оператор ОМСУ");

                if (contract.StartDate < contract.EndDate)
                {
                    contrReg.Update(contract);
                }
                else
                {
                    throw new Exception("Нельзя изменить контракт с выбранными датами");
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        } 
    }
}
