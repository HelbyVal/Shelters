using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using SheltersServer.Models;
using SheltersServer.Registries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Services
{
    internal abstract class Service
    {
        protected UserReg userReg = new UserReg();
        protected UserRoleReg roleUserReg = new UserRoleReg();
        protected List<string> roles = new List<string>() { "Админ" };
        protected int CheckShelter(User user, int sheltid)
        {
            if (sheltid != user.Id_Shelter)
                throw new ArgumentException("Пользователь не обладает правами доступа к этому приюту!");
            return user.Id_Shelter;
        }

        public void CheckUser(User user)
        {
            userReg.CheckUser(user);
        }
        public void CheckRoles(int id_user, params string[] customRoles)
        {
            var newRoles = customRoles.ToList();
            newRoles.AddRange(roles);
            List<UserRole> usersRoles = roleUserReg.FindAllByUser(id_user);
            foreach (var roleName in newRoles)
            {
                foreach (var userRole in usersRoles)
                {
                    if (userRole.CheckRole(roleName) == true) 
                        return;
                }
            }
            throw new Exception("У пользователя недостаточно прав!");
        }
    }
}
