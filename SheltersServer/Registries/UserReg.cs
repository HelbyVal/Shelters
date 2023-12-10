using Microsoft.EntityFrameworkCore;
using SheltersServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Registries
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
        public User CheckUser(string userName, string Password)
        {
            var user = dbSet.Where(us => us.UserName == userName).Single();
            if (user.Password != Password)
            {
                throw new Exception("Неверный пароль");
            }
            return user;
        }

        public User CheckUser(User user)
        {
            var baseUser = dbSet.Where(us => us.Id_User == baseUser).Single();
            if (baseUser.Password != Password)
            {
                throw new Exception("Неверный пароль");
            }
            return baseUser;
        }
    }
}
