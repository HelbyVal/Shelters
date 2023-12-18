using Microsoft.EntityFrameworkCore;
using SheltersServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Registries
{
    internal class AnimalReg : Registry<Animal>
    {
        public AnimalReg() { }

        public (List<Animal>, int) GetAnimals(int lastId = 0,
                                       string filtSex = "",
                                       string filtType = "",
                                       double filtSize = -1,
                                       string filtColor = "",
                                       int filtChip = -1,
                                       int count = 5)
        {
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<Animal> dbSet = ContextDataBase.DB.Set<Animal>();
                var animals = dbSet.Where(x => true);

                if (filtColor != "") animals = animals.Where(anim => anim.Color == filtColor);
                if (filtSize != -1) animals = animals.Where(anim => anim.Size == filtSize);
                if (filtSex != "") animals = animals.Where(anim => anim.Sex == filtSex);
                if (filtType != "") animals = animals.Where(anim => anim.Type == filtType);
                if (filtChip != -1) animals = animals.Where(anim => anim.ChipNum == filtChip);

                int countPage = animals.Count() / count;
                animals.OrderBy(x => x.ChipNum)
                       .Where(x => x.ChipNum > lastId)
                       .Take(count);

                return (animals.ToList(), countPage);
            }
        }
        public override void Add(Animal entity)
        {
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<Animal> dbSet = ContextDataBase.DB.Set<Animal>();
                if (entity.ChipNum > 9999999)
                {
                    throw new ArgumentException("Число чипа должно быть меньше 1000000");
                }
                if (dbSet.Find(entity.ChipNum) != null)
                {
                    throw new ArgumentException("Это животное уже есть в базе");
                }
                base.Add(entity);
            }
        }
    }
}
