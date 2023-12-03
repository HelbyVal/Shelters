using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using SheltersServer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Registries
{
    internal class KeepingReg : Registry<Keeping>
    {
        public KeepingReg() {}

        public Keeping FindLastInAnimal(int chipNum)
        { 
            Keeping keep = dbSet.Where(x => x.ChipNum == chipNum).Last();
            return keep;
        }
        public List<Keeping> FindAllInContract(int id_contr, bool isFilled = false)
        {
            return dbSet.Where(x => x.Number == id_contr && x.IsFilled == isFilled).ToList();
        }
        public override void Add(Keeping entity)
        {
            Keeping oldKeep = FindLastInAnimal(entity.ChipNum);
            if (!oldKeep.IsFilled)
                throw new Exception("Животное уже есть в приюте");
            if (oldKeep.RelDate > entity.AccDate)
                throw new Exception("Животное нельзя добавть на эту дату");
            base.Add(entity);
        }
        public override void Update(Keeping entity)
        { 
            if (entity.IsFilled)
                throw new Exception("Животное уже выпущено из приюта");
            base.Update(entity);
        }
    }
}
