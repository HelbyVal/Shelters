﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Models
{
    public class User : IMyModel
    {
        [Key]
        public int Id_User { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int Id_Shelter { get; set; }
        public Shelter? Shelter { get; set; }
        public List<UserRole>? UserRole { get; set; }



    }
}
