using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SheltersServer.Models;
using SheltersServer.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Services
{
    internal class AnimalService : Service
    {
        AnimalReg animReg;
        ContractReg contrReg;
        KeepingReg keepReg;
        public AnimalService()
        {
            userReg = new UserReg();
            animReg = new AnimalReg();
            contrReg = new ContractReg();
        }

        public bool UpdateAnimal(int chipNum, User user, DateOnly dateAdding, int contr_num ,int sheltid = -1)
        {
            try
            {
                if (sheltid != -1)
                {
                    sheltid = CheckShelter(user, sheltid);
                    CheckRoles(user.Id_User, "Оператор приюта", "Ветврач приюта");
                }
                else CheckRoles(user.Id_User, "Ветврач");
                Contract contr = contrReg.Find(contr_num);
                Animal animal = animReg.Find(chipNum);
                var keep = new Keeping() { IsFilled = false, ChipNum = animal.ChipNum, Number = contr.Number };
                keep.AddAccDate(dateAdding);
                keepReg.Add(keep);
                return true;
            }
            catch (Exception exp) 
            {
                return false;
            }
        }

        public bool AddAnimal(int chipNum, double size, string color, string sex, string type,
                            User user, DateOnly dateAdding, int contr_num ,int sheltid = -1)
        {
            try
            {
                if (sheltid != -1) 
                {   
                    sheltid = CheckShelter(user, sheltid); 
                    CheckRoles(user.Id_User, "Оператор приюта", "Ветврач приюта");
                }
                else CheckRoles(user.Id_User, "Ветврач");

                Animal animal = new Animal() 
                { 
                    ChipNum = chipNum,
                    Size = size,
                    Color = color,
                    Sex = sex,
                    Type = type
                };
                animReg.Add(animal);
                var contr = contrReg.Find(contr_num);
                var keep = new Keeping() { IsFilled = false, ChipNum = animal.ChipNum, Number = contr.Number };
                keep.AddAccDate(dateAdding);
                keepReg.Add(keep);
                return true;   
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public bool ReleaseAnimal(int chipNum, User user, DateOnly dateRel, int sheltid = -1)
        {
            try
            {
                if (sheltid != -1)
                {
                    sheltid = CheckShelter(user, sheltid);
                    CheckRoles(user.Id_User, "Оператор приюта", "Ветврач приюта");
                }
                else CheckRoles(user.Id_User, "Ветврач");
                var keep = keepReg.FindLastInAnimal(chipNum);
                keep.AddRelDate(dateRel);
                keep.IsFilled = true;
                keepReg.Update(keep);
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public (List<Animal>, int) GetAnimals(User user,
                                       string filtSex,
                                       string filtType,
                                       int filtChip,
                                       string filtColor,
                                       double filtSize,
                                       int lastId,
                                       int sheltid)
        {
            try
            {
                var res = animReg.GetAnimals(lastId, filtSex, filtType, filtSize, filtColor, filtChip);
                List<Animal> resultAnimal = new List<Animal>();
                if (sheltid == -1)
                {
                    CheckRoles(user.Id_User, "Оператор приюта", "Ветврач приюта");
                    sheltid = CheckShelter(user, sheltid);
                    AddAnimalsToResult(sheltid, res.Item1, resultAnimal);
                }
                else
                {
                    CheckRoles(user.Id_User, "Ветврач");
                    AddAnimalsToResult(sheltid, res.Item1, resultAnimal);
                }
                return (resultAnimal, res.Item2);
            }
            catch (Exception ex)
            {
                return (new List<Animal>(), 0);
            }
        }

        private void AddAnimalsToResult(int sheltid, List<Animal> res, List<Animal> resultAnimal)
        {
            List<Contract> contrs = contrReg.GetContracts(sheltid, true);
            foreach (var contr in contrs)
            {
                List<Keeping> keeps = contr.Keepings;
                foreach (var anim in res)
                {
                    foreach (var keep in keeps)
                    {
                        if (anim.Keepings.Where(x => x.Id_Keeping == keep.Id_Keeping).FirstOrDefault() != default(Keeping))
                        {
                            res.Remove(anim);
                            resultAnimal.Add(anim);
                        }
                    }
                }
            }
        }
    }
}
