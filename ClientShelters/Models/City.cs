using SheltersServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Models
{
    public class City : IMyModel
    {
        public int Id_City { get; set; }
        public string? Name { get; set; }
        public string? Subject { get; set; }
        public List<Shelter>? Shelters { get; set; }
        public static City ToCity(CityReply reply)
        {
            return new City()
            {
                Id_City = reply.IdCity,
                Name = reply.Name,
                Subject = reply.Subject
            };
        }
    }

}
