using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class City : IMyModel
    {
        [Key]
        public int Id_City { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public List<Shelter>? Shelters { get; set; }
    }
}
