using Shelters.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Services
{
    internal abstract class ProtectedService
    {
        protected UserReg userReg;

        protected int FindShelter(int id_User, string Password)
        {
            return userReg.TakeShelterId(id_User, Password);
        }
    }
}
