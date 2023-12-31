﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Models
{
    public class Shelter : IMyModel
    {
        [Key]
        public int Id_Shelter { get; set; }
        public string? Name {get; set;}
        public string? INN { get; set; }
        public string? KPP { get; set;}
        public string? OrgType { get; set;}
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
