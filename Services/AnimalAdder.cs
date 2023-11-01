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
    internal class AnimalAdder : ProtectedService
    {
        AnimalReg animReg;
        ContractReg contrReg;
        KeepingReg keepReg;
        public AnimalAdder()
        {
            userReg = new UserReg();
            animReg = new AnimalReg();
            contrReg = new ContractReg();
            keepReg = new KeepingReg();
        }

        public bool AddAnimal(int chipNum, double size, string color, string sex, string type, int id_User, string password, DateOnly dateAdding)
        {
            try
            {
                int sheltid = FindShelter(id_User, password);
                Contract contr = contrReg.FindLastShelterContract(sheltid);
                Animal animal = new Animal() { ChipNum = chipNum, Size = size, Color = color,
                                               Sex = sex, Type = type};
                animReg.Add(animal);
                keepReg.Add(new Keeping() { AccDate = dateAdding, ChipNum = animal.ChipNum, Number = contr.Number });
                return true;   
            }
            catch (Exception exp)
            {
                return false;
            }
        }
    }
}
