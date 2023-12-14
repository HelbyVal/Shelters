using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ClientShelters.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class NameAttribute : Attribute
    {
        public string Name { get; set; }
        public NameAttribute(string name) => Name = name;
    }
}
