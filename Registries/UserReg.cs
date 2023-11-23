using Microsoft.EntityFrameworkCore;
using Shelters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shelters.Registries
{
    internal class UserReg : Registry<User>
    {
        public UserReg() {}

        public User CheckUser(int Id_User, string Password)
        {
            var user = dbSet.Where(us => us.Id_User == Id_User).Single();
            if (user.Password != Password)
            {
                throw new Exception("Неверный пароль");
            }
            return user;
        }
    }
}
