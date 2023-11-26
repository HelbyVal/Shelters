using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Models
{
    public class UserRole : IMyModel
    {
        [Key]
        public int Id_UserRole { get; set; }
        public int Id_Role { get; set; }
        public Role? Role { get; set; }
        public int Id_User { get; set; }
        public User? User { get; set; }

        public bool CheckRole(string name)
        {
            return Role.Name == name;
        }

    }
}
