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
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<User> dbSet = ContextDataBase.DB.Set<User>();
                var user = dbSet.Where(us => us.Id_User == Id_User).Single();
                if (user.Password != Password)
                {
                    throw new Exception("Неверный пароль");
                }
                return user;
            }
        }
        public User CheckUser(string userName, string Password)
        {
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<User> dbSet = ContextDataBase.DB.Set<User>();
                var user = dbSet.Include(x => x.Shelter).Where(us => us.UserName == userName).Single();
                if (user.Password != Password)
                {
                    throw new Exception("Неверный пароль");
                }
                return user;
            }
        }

        public void CheckUser(User user)
        {
            using (ContextDataBase db = new ContextDataBase())
            {
                DbSet<User> dbSet = ContextDataBase.DB.Set<User>();
                var baseUser = dbSet.Where(us => us.Id_User == user.Id_User).Single();
                if (baseUser.Password != user.Password)
                {
                    throw new Exception("Неверный пароль");
                }
            }
        }
    }
}
