using ClientShelters.Models;
using Grpc.Net.Client;
using SheltersServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ClientShelters.Controllers
{
    internal class ShelterController
    {
        public (List<Shelter>, int) GetShelters(User user,
                                         int pageSize,
                                         int lastId = 0,
                                         int filtCity = -1,
                                         int filtShelter = -1,
                                         string filtOrgType = "",
                                         string filtName = "",
                                         string filtINN = "",
                                         string filtKPP = "")
        {
            GetSheltersRequest req = new GetSheltersRequest()
            {
                User = user.ToReply(),
                FiltCity = filtCity,
                FiltShelter = filtShelter,
                FiltINN = filtINN,
                FiltKPP = filtKPP,
                LastId = lastId,
                FiltName = filtName,
                FiltOrgType = filtOrgType,
                PageSize = pageSize,
            };
            using var channel = GrpcChannel.ForAddress("https://localhost:7013");
            var client = new ShelterPr.ShelterPrClient(channel);
            var reply = client.GetShelters(req);
            List<Shelter> result = new List<Shelter>();
            foreach (var item in reply.Shelter.ToList())
            {
                result.Add(Shelter.ToShelter(item));
            }
            return (result, reply.CountPage);
        }

        public bool AddShelter(User user, Shelter shelter)
        {
            AddShelterRequest req = new AddShelterRequest()
            {
                User = user.ToReply(),
                Name = shelter.Name,
                INN = shelter.INN,
                KPP = shelter.KPP,
                OrgType = shelter.OrgType,
                IdCity = shelter.Id_City
            };
            using var channel = GrpcChannel.ForAddress("https://localhost:7013");
            var client = new ShelterPr.ShelterPrClient(channel);
            var result = client.CreateShelter(req);
            return result.IsCorrect;
        }

        public List<City> GetCities(User user)
        {
            OnlyUser req = new OnlyUser()
            {
                User = user.ToReply()
            };
            using var channel = GrpcChannel.ForAddress("https://localhost:7013");
            var client = new ShelterPr.ShelterPrClient(channel);
            var res = client.GetCitites(req);
            List<City> result = new List<City>();
            foreach (var item in res.CityReply.ToList())
            {
                result.Add(City.ToCity(item));
            }
            return result;
        }

        public bool DeleteShelter(User user, int Id_Shelter)
        {
            DeleteShelterRequest req = new DeleteShelterRequest()
            {
                User = user.ToReply(),
                IdShelter = Id_Shelter
            };
            using var channel = GrpcChannel.ForAddress("https://localhost:7013");
            var client = new ShelterPr.ShelterPrClient(channel);
            var res = client.DeleteShelter(req);
            return res.IsCorrect;
        }
    }
}
