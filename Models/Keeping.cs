﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Models
{
    internal class Keeping
    {
        [Key]
        public int Id_Keeping { get; set; }
        public DateOnly AccDate {  get; set; }
        public DateOnly RelDate { get; set; }
    }
}
