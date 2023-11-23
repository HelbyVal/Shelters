using Microsoft.EntityFrameworkCore;
using Shelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Registries
{
    internal class AnimalReg : Registry<Animal>
    {
        public AnimalReg() { }

        public List<Animal> GetAnimals(string filtSex = "", string filtType = "", int filtChip = -1)
        {
            var animals = dbSet.Include(x => x.ChipNum);
            if (filtSex != "") animals.Where(anim => anim.Sex == filtSex);
            if (filtType != "") animals.Where(anim => anim.Type == filtType);
            if (filtChip != -1) animals.Where(anim => anim.ChipNum == filtChip);
            return animals.ToList();
        }
    }
}
