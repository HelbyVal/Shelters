using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Models
{
    internal class UserRole
    {
        [Key]
        public int Id_UserRole { get; }
        public int Id_Role { get; set; }
        public Role? Role { get; set; }
        public int Id_User { get; set; }
        public User? User { get; set; }
    }
}
