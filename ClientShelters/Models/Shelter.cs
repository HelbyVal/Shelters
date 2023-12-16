using SheltersServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Models
{
    public class Shelter : IMyModel
    {
        string inn;
        string kpp;
        string name;
        string orgType;

        [NameAttribute("Номер приюта")]
        public int Id_Shelter { get; set; }
        [NameAttribute("Название приюта")]
        public string? Name 
        { 
            get
            {
                return name;
            }
            set
            {
                if (value == "") 
                {
                    throw new ArgumentException("Поле имени не должно быть пустым");
                }
                name = value;
            }
        }
        [NameAttribute("ИНН")]
        public string? INN
        {
            get
            {
                return inn;
            }
            set
            {
                foreach (var item in value)
                {
                    if (!Char.IsDigit(item))
                        throw new ArgumentException("ИНН должен состоять только из цифр");
                }
                if (value.Length != 10)
                    throw new ArgumentException("ИНН должен состоять из 10 цифр");
                inn = value;
            }
        }
        [NameAttribute("КПП")]
        public string? KPP 
        { 
            get
            {
                return kpp;
            }
            set
            {
                foreach (var item in value)
                {
                    if (!Char.IsDigit(item))
                        throw new ArgumentException("КПП должен состоять из 9 цифр");
                }
                if (value.Length != 9)
                    throw new ArgumentException("ИНН должен состоять из 9 цифр");
                kpp = value;
            }
        }
        [NameAttribute("Тип организации")]
        public string? OrgType
        {
            get
            {
                return orgType;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Поле типа организации не должно быть пустым");
                }
                orgType = value;
            }
        }
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

        public static Shelter ToShelter(ShelterReply reply)
        {
            Shelter result = new Shelter()
            {
                Id_Shelter = reply.IdShelter,
                Name = reply.Name,
                INN = reply.INN,
                KPP = reply.KPP,
                OrgType = reply.OrgType,
                Id_City = reply.IdCity,
            };
            return result;
        }

    }
}
