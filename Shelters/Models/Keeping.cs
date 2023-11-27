using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Models
{
    public class Keeping : IMyModel
    {
        [Key]
        public int Id_Keeping { get; set; }
        public DateOnly AccDate {  get; set; }
        public DateOnly RelDate { get; set; }
        public bool IsFilled { get; set; }
        public int ChipNum { get; set; }
        public Animal? Animal { get; set; }
        public int Number { get; set; }
        public Contract? Contract { get; set; }

        public void AddRelDate(DateOnly relDate)
        {
            if (relDate < AccDate || relDate < Contract.StartDate || relDate > Contract.EndDate)
            {
                throw new ArgumentException("Невозможно выпустить животное из приюта в выбранную дату");
            }
            RelDate = relDate;
            IsFilled = true;
        }

        public void AddAccDate(DateOnly accDate)
        {
            if(accDate < Contract.StartDate || accDate > Contract.EndDate)
            {
                throw new ArgumentException("Невозможно добавть животное в выбранную дату");
            }
            AccDate = accDate;
            IsFilled = false;
        }

        public Keeping CreateCopy(Contract cont)
        {
            Keeping newKeep = new Keeping() { AccDate = cont.StartDate, ChipNum = this.ChipNum, Number = cont.Number, IsFilled = false };
            return newKeep;
        }

        public int GetDays(DateOnly start, DateOnly end)
        {
            DateOnly accDate = AccDate;
            DateOnly relDate = RelDate;
            if (!IsFilled) relDate = end; 
            if (start > accDate) accDate = start;
            if (end < relDate) relDate = end;
            return relDate.DayNumber - accDate.DayNumber + 1;
        }
    }
}
