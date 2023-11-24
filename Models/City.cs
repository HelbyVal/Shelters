using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Models
{
    public class City
    {
        [Key]
        public int Id_City { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public bool IsActive { get; set; }
        public List<Shelter>? Shelters { get; set; }
    }
}
