using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters
{
    internal class ContextDataBase : DbContext
    {
        private bool active = false;
        public ContextDataBase()
        {
            if (!active)
                active = true;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("host=localhost;port=5432;Database=SheltersAnimals;username=postgres;password=1234;Include Error Detail=true");
        }
    }
}
