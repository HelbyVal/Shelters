using Grpc.Core;
using SheltersServer.Models;
using SheltersServer.Services;

namespace SheltersServer.Controllers
{
    public class AnimalController : Animaling.AnimalingBase
    {
        private readonly ILogger<AnimalController> _logger;
        private readonly AnimalService animalService = new AnimalService();
        public AnimalController(ILogger<AnimalController> logger)
        {
            _logger = logger;
        }

        public override Task<IsCorrect> AddAnimal(AddingAnimal request, ServerCallContext context)
        {
            bool isCorrect = animalService.AddAnimal(request.ChipNum, 
                                    request.Size,
                                    request.Color,
                                    request.Sex,
                                    request.Type,
                                    User.ToUser(request.User),
                                    DateOnly.FromDateTime(request.DateAdding.ToDateTime()),
                                    request.ContrNum,
                                    request.Sheltid);

            IsCorrect res = new IsCorrect() {  IsCorrect_ = isCorrect };
            return Task.FromResult(res);
        }

        public override Task<IsCorrect> UpdateAnimal(UpdatingAnimal request, ServerCallContext context)
        {
            bool isCorrect = animalService.UpdateAnimal(request.ChipNum,
                                                        User.ToUser(request.User),
                                                        DateOnly.FromDateTime(request.DateAdding.ToDateTime()),
                                                        request.ContrNum,
                                                        request.Sheltid);

            IsCorrect res = new IsCorrect() { IsCorrect_ = isCorrect };
            return Task.FromResult(res);
        }

        public override Task<IsCorrect> ReleaseAnimal(ReleasingAnimal request, ServerCallContext context)
        {
            bool isCorrect = animalService.ReleaseAnimal(request.ChipNum,
                                                         User.ToUser(request.User),
                                                         DateOnly.FromDateTime(request.DateRel.ToDateTime()),
                                                         request.Sheltid);

            IsCorrect res = new IsCorrect() { IsCorrect_ = isCorrect };
            return Task.FromResult(res);
        }

        public override Task<AnimalsReply> GetAnimals(AnimalsFilts request, ServerCallContext context)
        {
            AnimalsReply res = new AnimalsReply();
            var animals = animalService.GetAnimals(User.ToUser(request.User),
                                                   request.FiltSex,
                                                   request.FiltType,
                                                   request.FiltChip,
                                                   request.FiltColor,
                                                   request.FiltSize,
                                                   request.LastId,
                                                   request.Sheltid);
            List<AnimalReply> repls = new List<AnimalReply>();
            foreach (var item in animals.Item1)
            {
                repls.Add(item.ToReply());
            }
            res.Animal.AddRange(repls);
            res.CountPage = repls.Count;
            return Task.FromResult(res);
        }
    }
}
