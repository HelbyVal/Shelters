using Grpc.Core;
using Microsoft.AspNetCore.Components.Routing;
using SheltersServer;
using SheltersServer.Models;
using SheltersServer.Services;
using System.Diagnostics.Contracts;

public class ShelterController : ShelterPr.ShelterPrBase
{
    private readonly ILogger<ShelterController> _logger;
    private readonly ShelterService shelterService = new ShelterService();
    public ShelterController(ILogger<ShelterController> logger)
    {
        _logger = logger;
    }

    public override Task<isCorrectShelt> CreateShelter(AddShelterRequest request, ServerCallContext context)
    {
        bool res = shelterService.CreateShelter(User.ToUser(request.User),
                                               request.Name,
                                               request.INN,
                                               request.KPP,
                                               request.OrgType,
                                               request.IdCity);

        isCorrectShelt resuslt = new isCorrectShelt() { IsCorrect = res };
        return Task.FromResult(resuslt);
    }

    public override Task<isCorrectShelt> DeleteShelter(DeleteShelterRequest request, ServerCallContext context)
    {
        bool res = shelterService.DeleteShelter(User.ToUser(request.User), request.IdShelter);

        isCorrectShelt resuslt = new isCorrectShelt() { IsCorrect = res };
        return Task.FromResult(resuslt);
    }

    public override Task<SheltersReply> GetShelters(GetSheltersRequest request, ServerCallContext context)
    {
        SheltersReply res = new SheltersReply();
        var shelters = shelterService.GetShelters(User.ToUser(request.User),
                                             request.FiltCity,
                                             request.FiltShelter,
                                             request.FiltOrgType,
                                             request.FiltName,
                                             request.FiltINN,
                                             request.FiltKPP,
                                             request.LastId);

        List<ShelterReply> repls = new List<ShelterReply>();
        foreach (var item in shelters.Item1)
        {
            repls.Add(item.ToReply());
        }
        res.Shelter.AddRange(repls);
        res.CountPage = repls.Count;
        return Task.FromResult(res);
    }
}

