using SheltersServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Models
{
    [Id("Number")]
    public class Contract : IMyModel
    {
        public Contract() { }
        public Contract(double costPerDay, DateOnly startDate, DateOnly endDate, int id_Shelter)
        {
            CostPerDay = costPerDay;
            if (startDate <= endDate) throw new Exception("Указан невозможный промежуток дат для контракта");
            StartDate = startDate;
            EndDate = endDate;
            Id_Shelter = id_Shelter;
        }

        [NameAttribute("Номер контракта")]
        public int Number { get; set; }
        [NameAttribute("Стоимость за день")]
        public double CostPerDay { get; set; }
        [NameAttribute("Дата начала действия")]
        public DateOnly StartDate { get; set; }
        [NameAttribute("Дата окончания действия")]
        public DateOnly EndDate { get; set; }
        [NameAttribute("Номер приюта")]
        public int Id_Shelter { get; set; }
        public Shelter? Shelter { get; set; }
        public List<Keeping>? Keepings { get; set; }

        public double GetKeepingSum(DateOnly start, DateOnly end)
        {
            int days = 0;
            DateOnly startDate = StartDate;
            DateOnly endDate = EndDate;
            if (start > startDate) startDate = start;
            if (end < endDate) EndDate = end;
            foreach (var keep in Keepings)
            {
                days += keep.GetDays(startDate, endDate);    
            }
            return days * CostPerDay;
        }

        public ContractReply ToReply()
        {
            var res = new ContractReply()
            {
                Number = Number,
                CostPerDay = CostPerDay,
                IdShelter = Id_Shelter,
                StartDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(StartDate.ToDateTime(new TimeOnly())),
                EndDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(EndDate.ToDateTime(new TimeOnly())),
            };
            return res;
        }

        public static Contract ToContract(ContractReply reply)
        {
            var result = new Contract()
            {
                Number = reply.Number,
                CostPerDay = reply.CostPerDay,
                StartDate = DateOnly.FromDateTime(reply.StartDate.ToDateTime()),
                EndDate = DateOnly.FromDateTime(reply.EndDate.ToDateTime()),
                Id_Shelter = reply.IdShelter
            };
            return result;
        } 
    }
}
