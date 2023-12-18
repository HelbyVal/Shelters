using ClientShelters.Models;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using SheltersServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Controllers
{
    internal class ContractController : IController
    {

        DateOnly filtStartDate = new DateOnly();
        DateOnly filtEndDate = new DateOnly(2100,1,1);
        double filtStartCost = 0;
        double filtEndCost = int.MaxValue;
        int filtShelt = -1;
        int filtNum = -1;
        bool includeKeeps = true;
        bool allShelts = true;
        void SetFilts(DateOnly filtStartDate,
                      DateOnly filtEndDate,
                      double filtStartCost,
                      double filtEndCost,
                      int filtShelt,
                      int filtNum,
                      bool allShelts,
                      bool includeKeeps = false)
        {
            this.filtEndDate = filtStartDate;
            this.filtEndDate = filtEndDate;
            this.filtStartCost = filtStartCost;
            this.filtEndCost = filtEndCost;
            this.filtNum = filtNum;
            this.allShelts = allShelts;
            this.filtShelt = filtShelt;
            this.includeKeeps = includeKeeps;
        }
        public (List<Contract>, int) GetContracts(User user,
                                                  int pageSize,
                                                  int lastId)
        {
            GetContratsRequest request = new GetContratsRequest()
            {
                User = user.ToReply(),
                FiltNum = filtNum,
                IdShelter = filtShelt,
                FiltDateStart = filtStartDate.FromDateOnlyToStamp(),
                FiltDateEnd = filtEndDate.FromDateOnlyToStamp(),
                FiltCostStart = filtStartCost,
                FiltCostEnd = filtEndCost,
                IncludeKeep = includeKeeps,
                AllShelters = allShelts,
                LastId = lastId
            };
            using var channel = GrpcChannel.ForAddress("https://localhost:7013");
            var client = new ContractCon.ContractConClient(channel);
            var reply = client.GetContrats(request);
            List<Contract> contracts = new List<Contract>();
            foreach (var item in reply.Contracts)
            {
                contracts.Add(Contract.ToContract(item));
            }
            return (contracts, reply.CountPage);
        }

        public bool CreateContract(User user, Contract con)
        {
            AddContractRequest req = new AddContractRequest()
            {
                User = user.ToReply(),
                CostPerDay = con.CostPerDay,
                StartDate = con.StartDate.FromDateOnlyToStamp(),
                EndDate = con.EndDate.FromDateOnlyToStamp(),
                IdShelter = con.Id_Shelter
            };
            using var channel = GrpcChannel.ForAddress("https://localhost:7013");
            var client = new ContractCon.ContractConClient(channel);
            var reply = client.CreateNewContract(req);
            return reply.IsCorrect;
        }

        public bool DeleteContract(User user, int Number)
        {
            DeleteContractRequest req = new DeleteContractRequest()
            {
                User = user.ToReply(),
                NumberContr = Number
            };
            using var channel = GrpcChannel.ForAddress("https://localhost:7013");
            var client = new ContractCon.ContractConClient(channel);
            var reply = client.DeleteContract(req);
            return reply.IsCorrect;
        }

        public void CancelFilters()
        {
            filtStartDate = new DateOnly();
            filtEndDate = new DateOnly(2100, 1, 1);
            filtStartCost = 0;
            filtEndCost = int.MaxValue;
            filtShelt = -1;
            filtNum = -1;
            includeKeeps = true;
            allShelts = true;
        }

        public (List<IMyModel>, int) GetEntities(User user, int pageSize, int lastId)
        {
            var result = new List<IMyModel>();
            var entities = GetContracts(user, pageSize, lastId);
            result.AddRange(entities.Item1);
            return (result, entities.Item2);
        }

        public bool UpadateContract(User user, Contract contract)
        {
            ContractReply reply = contract.ToReply();
            UpdateContractRequest req = new UpdateContractRequest()
            {
                User = user.ToReply(),
                Contract = reply
            };
            using var channel = GrpcChannel.ForAddress("https://localhost:7013");
            var client = new ContractCon.ContractConClient(channel);
            var result = client.UpdateContract(req);
            return result.IsCorrect;
        }

        public bool DeleteEntity(User user, int id)
        {
            return DeleteContract(user, id);
        }

        public bool UpdateEntity(User user, IMyModel entity)
        {
            return UpadateContract(user, (Contract)entity);
        }
    }
}
