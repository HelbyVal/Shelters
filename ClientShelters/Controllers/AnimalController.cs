using ClientShelters.Models;
using Grpc.Net.Client;
using Microsoft.VisualBasic.Logging;
using SheltersServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Controllers
{
    internal class AnimalController
    {
        public AnimalController() { }

        public List<Animal> GetAnimals(User user,
                                       string filtSex,
                                       string filtType,
                                       int filtChip,
                                       string filtColor,
                                       double filtSize,
                                       int lastId,
                                       int sheltid)
        {
            UserReply userReply = user.ToReply();
            var req = new AnimalsFilts()
            {
                User = userReply,
                FiltChip = filtChip,
                FiltColor = filtColor,
                FiltSize = filtSize,
                LastId = lastId,
                Sheltid = sheltid,
                FiltSex = filtSex,
                FiltType = filtType,
            };
            using var channel = GrpcChannel.ForAddress("https://localhost:7013");
            var client = new Animaling.AnimalingClient(channel);
            var res = client.GetAnimals(req);
            List<Animal> result = new List<Animal>();
            foreach (var item in res.Animal.ToList())
            {
                result.Add(Animal.ToAnimal(item));
            }
            return result;
        }
    }
}
