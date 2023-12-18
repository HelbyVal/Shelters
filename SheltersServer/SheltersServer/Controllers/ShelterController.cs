using ClientShelters;
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
    private readonly CityService cityService = new CityService();
    public ShelterController(ILogger<ShelterController> logger)
    {
        _logger = logger;
    }

    public override Task<isCorrectShelt> CreateShelter(AddShelterRequest request, ServerCallContext context)
    {
        shelterService.CheckUser(User.ToUser(request.User));

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
        shelterService.CheckUser(User.ToUser(request.User));

        bool res = shelterService.DeleteShelter(User.ToUser(request.User), request.IdShelter);

        isCorrectShelt resuslt = new isCorrectShelt() { IsCorrect = res };
        return Task.FromResult(resuslt);
    }

    public override Task<SheltersReply> GetShelters(GetSheltersRequest request, ServerCallContext context)
    {
        shelterService.CheckUser(User.ToUser(request.User));

        SheltersReply res = new SheltersReply();
        var shelters = shelterService.GetShelters(User.ToUser(request.User),
                                             request.FiltCity,
                                             request.FiltShelter,
                                             request.FiltOrgType,
                                             request.FiltName,
                                             request.FiltINN,
                                             request.FiltKPP,
                                             request.LastId,
                                             request.PageSize);

        List<ShelterReply> repls = new List<ShelterReply>();
        foreach (var item in shelters.Item1)
        {
            repls.Add(item.ToReply());
        }
        res.Shelter.AddRange(repls);
        res.CountPage = shelters.Item2;
        return Task.FromResult(res);
    }

    public override Task<CitiesReply> GetCitites(OnlyUser request, ServerCallContext context)
    {
        CitiesReply res = new CitiesReply();
        var cities = cityService.GetCities(User.ToUser(request.User));
        List<CityReply> repls = new List<CityReply>();
        foreach (var item in cities)
        {
            repls.Add(item.ToReply());
        }
        res.CityReply.Add(repls);
        return Task.FromResult(res);
    }

    public override Task<isCorrectShelt> UpdateShelter(ShelterRequest request, ServerCallContext context)
    {
        Shelter shelter = Shelter.ToShelter(request.Shelt);
        bool isCorrect = shelterService.UpdateShelter(User.ToUser(request.User), shelter);
        return Task.FromResult(new isCorrectShelt() { IsCorrect = isCorrect});
    }
}

