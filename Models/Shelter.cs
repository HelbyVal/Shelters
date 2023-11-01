using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Models
{
    internal class Shelter
    {
        [Key]
        public string Id_Shelter { get; }
        public string INN { get; set; }
        public string KPP { get; set;}
        public string OrgType { get; set;}
        public string Id_City { get; set; }
        public List<Contract> Contracts { get; set; }
        public List<User> Users { get; set; }

    }
}
