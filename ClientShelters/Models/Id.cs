using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Models
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class Id : Attribute
    {
        public string IdName { get; set; }
        public Id(string name) => IdName = name;
    }
}
