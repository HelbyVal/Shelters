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
    internal class AnimalController : IController
    {
        string filtSex = "";
        string filtType = "";
        int filtChip = -1;
        string filtColor = "";
        double filtSize = -1;
        int filtShelter = -1;

        void SetFitres(string filtSex = "",
                       string filtType = "",
                       int filtChip = -1,
                       string filtColor = "",
                       double filtSize = -1,
                       int filtShelter = -1)
        {
            this.filtSex = filtSex;
            this.filtType = filtType;
            this.filtChip = filtChip;
            this.filtColor = filtColor;
            this.filtSize = filtSize;
            this.filtShelter = filtShelter;
        }

        public void CancelFilters()
        {
            filtSex = "";
            filtType = "";
            filtChip = -1;
            filtColor = "";
            filtSize = -1;
            filtShelter = -1;
        }

        public AnimalController() { }

        public (List<Animal>, int) GetAnimals(User user,                       
                                       int pageSize,
                                       int lastId)
        {
            UserReply userReply = user.ToReply();
            var req = new AnimalsFilts()
            {
                User = userReply,
                FiltChip = filtChip,
                FiltColor = filtColor,
                FiltSize = filtSize,
                LastId = lastId,
                Sheltid = filtShelter,
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
            return (result, res.CountPage);
        }

        public (List<IMyModel>, int) GetEntities(User user, int pageSize, int lastId)
        {
            var result = new List<IMyModel>();
            var entities = GetAnimals(user, pageSize, lastId);
            result.AddRange(entities.Item1);
            return (result, entities.Item2);
        }

        public bool DeleteEntity(User user, int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntity(User user, IMyModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
