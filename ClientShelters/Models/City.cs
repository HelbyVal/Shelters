using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Models
{
    public class City : IMyModel
    {
        public int Id_City { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public List<Shelter>? Shelters { get; set; }
    }
}
