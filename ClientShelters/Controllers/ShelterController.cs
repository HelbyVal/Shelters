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
    internal class ShelterController : IController
    {
        int filtCity = -1;
        int filtShelter = -1;
        string filtOrgType = "";
        string filtName = "";
        string filtINN = "";
        string filtKPP = "";
        public void SetFilters(int filtCity = -1,
                               int filtShelter = -1,
                               string filtOrgType = "",
                               string filtName = "",
                               string filtINN = "",
                               string filtKPP = "")
        {
            this.filtCity = filtCity;
            this.filtShelter = filtShelter;
            this.filtOrgType = filtOrgType;
            this.filtName = filtName;
            this.filtINN = filtINN;
            this.filtKPP = filtKPP;
        }

        public void CancelFilters()
        {
            filtCity = -1;
            filtShelter = -1;
            filtOrgType = "";
            filtName = "";
            filtINN = "";
            filtKPP = "";
        }
        public (List<Shelter>, int) GetShelters(User user,
                                         int pageSize,
                                         int lastId = 0)
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
            if (result.Count() == 0)
            {
                throw new Exception("Нет данных");
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

        public (List<IMyModel>, int) GetEntities(User user, int pageSize, int lastId)
        {
            var result = new List<IMyModel>();
            var entities = GetShelters(user, pageSize, lastId);
            result.AddRange(entities.Item1);
            return (result, entities.Item2);
        }

        public bool UpdateShelter(User user, Shelter shelter)
        {
            ShelterReply shelt = shelter.ToReply();
            ShelterRequest req = new ShelterRequest()
            {
                User = user.ToReply(),
                Shelt = shelt
            };
            using var channel = GrpcChannel.ForAddress("https://localhost:7013");
            var client = new ShelterPr.ShelterPrClient(channel);
            var result = client.UpdateShelter(req);
            return result.IsCorrect;
        }

        public bool DeleteEntity(User user, int id)
        {
            return DeleteShelter(user, id);
        }

        public bool UpdateEntity(User user, IMyModel entity)
        {
            return UpdateShelter(user, (Shelter)entity);
        }
    }
}
