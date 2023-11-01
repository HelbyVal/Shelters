using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Models
{
    internal class Role
    {
        [Key]
        public int Id_Role { get; }
        public string Name { get; set; }
        public List<UserRole> UserRole { get; set; }
    }
}
