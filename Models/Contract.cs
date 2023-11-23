using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Models
{
    internal class Contract
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

        [Key]
        public int Number { get; set; }
        public double CostPerDay { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int Id_Shelter { get; set; }
        public Shelter? Shelter { get; set; }
        public List<Keeping>? Keepings { get; set; }

    }
}
