using ClientShelters;
using Grpc.Core;
using SheltersServer;
using SheltersServer.Models;
using SheltersServer.Services;

    public class ContractController : ContractCon.ContractConBase
    {
        private readonly ILogger<ContractController> _logger;
        private readonly ContractService contractService = new ContractService();
        public ContractController(ILogger<ContractController> logger)
        {
            _logger = logger;
        }

        public override Task<ContractsReply> GetContrats(GetContratsRequest request, ServerCallContext context)
        {
            contractService.CheckUser(User.ToUser(request.User));

            ContractsReply res = new ContractsReply();
            var contracts = contractService.GetContracts(User.ToUser(request.User),
                                                      request.IdShelter,
                                                      request.FiltNum,
                                                      request.FiltCostStart,
                                                      request.FiltCostEnd,
                                                      DateOnly.FromDateTime(request.FiltDateStart.ToDateTime()),
                                                      DateOnly.FromDateTime(request.FiltDateEnd.ToDateTime()),
                                                      request.LastId,
                                                      request.IncludeKeep,
                                                      request.AllShelters);
            List<ContractReply> repls = new List<ContractReply>();
            foreach (var item in contracts.Item1)
            {
                repls.Add(item.ToReply());
            }
            res.Contracts .AddRange(repls);
            res.CountPage = contracts.Item2;
            return Task.FromResult(res);
        }

        public override Task<isCorrectContr> CreateNewContract(AddContractRequest request, ServerCallContext context)
        {
            contractService.CheckUser(User.ToUser(request.User));

            bool isCorrect = contractService.CreateNewContract(User.ToUser(request.User),
                                                               request.CostPerDay,
                                                               DateOnly.FromDateTime(request.StartDate.ToDateTime()),
                                                               DateOnly.FromDateTime(request.EndDate.ToDateTime()),
                                                               request.IdShelter);
            isCorrectContr res = new isCorrectContr() { IsCorrect = isCorrect};
            return Task.FromResult(res);
        }

        public override Task<isCorrectContr> DeleteContract(DeleteContractRequest request, ServerCallContext context)
        {   
            contractService.CheckUser(User.ToUser(request.User));

            bool isCorrect = contractService.DeleteContract(User.ToUser(request.User), request.NumberContr);
            isCorrectContr res = new isCorrectContr() { IsCorrect = isCorrect };
            return Task.FromResult(res);
        }

    public override Task<isCorrectContr> UpdateContract(UpdateContractRequest request, ServerCallContext context)
    {
        Contract contr = Contract.ToContract(request.Contract);
        bool isCorrect = contractService.UpdateContract(User.ToUser(request.User), contr);
        return Task.FromResult(new isCorrectContr() { IsCorrect = isCorrect });
    }
}
