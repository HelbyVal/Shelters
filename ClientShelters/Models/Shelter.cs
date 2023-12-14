using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Models
{
    public class Shelter : IMyModel
    {
        [NameAttribute("Номер приюта")]
        public int Id_Shelter { get; set; }
        [NameAttribute("Название приюта")]
        public string? Name {get; set;}
        [NameAttribute("ИНН")]
        public string? INN { get; set; }
        [NameAttribute("КПП")]
        public string? KPP { get; set;}
        [NameAttribute("Тип организации")]
        public string? OrgType { get; set;}
        [NameAttribute("Номер Города")]
        public int Id_City { get; set; }
        public City? City { get; set; }
        public List<Contract>? Contracts { get; set; }
        public List<User>? Users { get; set; }

        public ShelterReply ToReply()
        {
            var res = new ShelterReply()
            {
                IdShelter = Id_Shelter,
                Name = Name,
                INN = INN,
                KPP = KPP,
                OrgType = OrgType,
                IdCity = Id_City
            };
            return res;
        }

    }
}
