using Shelters.Models;
using Shelters.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Services
{
    internal class ReportService : Service
    {
        CityReg cityReg;
        ShelterReg shelterReg;
        ContractReg contractReg;

        public ReportService() 
        {
            cityReg = new CityReg();
            shelterReg = new ShelterReg();
        }
        
        public Report GetReport(User user,DateOnly start, DateOnly end, int id_city)
        {
            CheckRoles(user.Id_User, "Оператор ОМСУ", "Куратор ОМСУ");
            City city = cityReg.Find(id_city);
            Report report = new Report() { CityName = city.Name, Start = start, End = end}; 
            List<Shelter> shelters = shelterReg.GetShelters(id_city);
            double summ = 0;
            foreach (var shelter in shelters)
            {
                double perSheltSumm = 0;
                List<Contract> contracts = contractReg.GetContracts(shelter.Id_Shelter, true);
                foreach (var contract in contracts)
                {
                    perSheltSumm += contract.GetKeepingSum(start, end);
                }
                report.SheltersCosts.Add(shelter.Name, perSheltSumm);
                summ += perSheltSumm;
            }
            report.Cost = summ;
            return report;
        }
    }
}
