using SheltersServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Models
{
    [Id("ChipNum")]
    public class Animal : IMyModel
    {
        [NameAttribute("Номер чипа")]
        public int ChipNum { get; set; }
        [NameAttribute("Размер")]
        public double Size { get; set; }
        [NameAttribute("Цвет")]
        public string? Color { get; set; }
        [NameAttribute("Пол")]
        public string? Sex { get; set; }
        [NameAttribute("Тип")]
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

        public static Animal ToAnimal(AnimalReply reply) 
        {
            Animal result = new Animal()
            {
                ChipNum = reply.ChipNum,
                Size = reply.Size,
                Color = reply.Color,
                Sex = reply.Sex,
                Type = reply.Type,
            };
            return result;
        }
    }
}
