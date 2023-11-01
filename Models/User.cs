using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Models
{
    internal class User
    {
        [Key]
        public int Id_User { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<UserRole> UserRole { get; set; }

    }
}
