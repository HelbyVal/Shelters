using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Models
{
    public class Animal : IMyModel
    {
        public int ChipNum { get; set; }
        public double Size { get; set; }
        public string? Color { get; set; }
        public string? Sex { get; set; }
        public string? Type { get; set; }
        public List<Keeping>? Keepings { get; set; }

        public AnimalReply ToReply()
        {
            var res = new AnimalReply() { Type = Type,
                                          ChipNum = ChipNum,
                                          Size = Size,
                                          Color = Color,
                                          Sex = Sex,
                                         };
            return res;
        }
    }
}
