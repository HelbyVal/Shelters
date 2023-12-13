using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Models
{
    public class Role : IMyModel
    {
        [Key]
        public int Id_Role { get; set; }
        public string? Name { get; set; }
        public List<UserRole>? UserRole { get; set; }
    }
}
