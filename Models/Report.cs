﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Models
{
    internal class Report
    {
        public DateOnly Start {  get; set; }
        public DateOnly End { get; set; }
        public string CityName { get; set; }
        public Dictionary<string, double> SheltersCosts = new Dictionary<string, double>();
        public double Cost { get; set; }

    }
}
