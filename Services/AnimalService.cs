using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Shelters.Models;
using Shelters.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Services
{
    internal class AnimalService : ProtectedService
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

        public bool UpdateAnimal(int chipNum, int id_User, string password, DateOnly dateAdding, int sheltid = -1)
        {
            try
            {
                User user = userReg.CheckUser(id_User, password);
                if (sheltid != -1)
                {
                    sheltid = CheckShelter(user, sheltid);
                    CheckRoles(id_User, "Оператор приюта", "Ветврач приюта");
                }
                else CheckRoles(id_User, "Ветврач");
                Contract contr = contrReg.FindLastShelterContract(sheltid);
                Animal animal = animReg.Find(chipNum);
                var keep = new Keeping() { IsFilled = false, ChipNum = animal.ChipNum, Number = contr.Number };
                keep.AddRelDate(dateAdding);
                keepReg.Add(keep);
                return true;
            }
            catch (Exception exp) 
            {
                return false;
            }
        }

        public bool AddAnimal(int chipNum, double size, string color, string sex, string type,
                            int id_User, string password, DateOnly dateAdding, int sheltid = -1)
        {
            try
            {
                User user = userReg.CheckUser(id_User, password);
                if (sheltid != -1) 
                {   
                    sheltid = CheckShelter(user, sheltid); 
                    CheckRoles(id_User, "Оператор приюта", "Ветврач приюта");
                }
                else CheckRoles(id_User, "Ветврач");
                
                Contract contr = contrReg.FindLastShelterContract(sheltid);
                Animal animal = new Animal() { ChipNum = chipNum, Size = size, Color = color,
                                               Sex = sex, Type = type};
                animReg.Add(animal);
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

        public bool ReleaseAnimal(int chipNum, int id_User, string password, DateOnly dateRel, int sheltid = -1)
        {
            try
            {
                User user = userReg.CheckUser(id_User, password);
                if (sheltid != -1)
                {
                    sheltid = CheckShelter(user, sheltid);
                    CheckRoles(id_User, "Оператор приюта", "Ветврач приюта");
                }
                else CheckRoles(id_User, "Ветврач");
                Contract contr = contrReg.FindLastShelterContract(sheltid);
                var keep = keepReg.FindLastForAnimal(chipNum);
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

        public List<Animal> GetAnimals(int id_user, string password, string filtSex, string filtType, string filtChip, int sheltid = -1)
        {
            try
            {
                User user = userReg.CheckUser(id_user, password);
                var res = animReg.GetAnimals();
                List<Animal> resultAnimal = new List<Animal>();
                if (sheltid != -1)
                {
                    sheltid = CheckShelter(user, sheltid);
                    CheckRoles(id_user, "Оператор приюта", "Ветврач приюта");
                    Contract contr = contrReg.FindLastShelterContract(sheltid, true);
                    List<Keeping> keeps = contr.Keepings;
                    foreach (var anim in res)
                    {
                        foreach (var keep in keeps)
                        {
                            if (anim.Keepings.Find(x => x.Id_Keeping == keep.Id_Keeping) != null)
                            {
                                resultAnimal.Add(anim);
                            }
                        }
                    }
                }
                else 
                {
                    CheckRoles(id_user, "Ветврач");

                }
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
