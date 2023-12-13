using SheltersServer.Models;
using SheltersServer.Registries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SheltersServer.Services
{
    internal class UserService : Service
    {
        public UserService() 
        {}

        public bool AddUser(User user, string name, string surname,
                            string lastname, string username, string newPassword, int id_shelt)
        {
            try
            {
                CheckRoles(user.Id_User);
                User newUser = new User()
                {
                    Name = name,
                    LastName = lastname,
                    Surname = surname,
                    UserName = username,
                    Password = newPassword,
                    Id_Shelter = id_shelt
                };
                userReg.Add(newUser);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteUser(User user,  int userId)
        {
            try
            {
                CheckRoles(user.Id_User);
                userReg.Delete(userReg.Find(userId));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddRoleToUser(User user, int id_role, int id_user)
        {
            try
            {
                CheckRoles(user.Id_User);
                UserRole userRole = new UserRole() { Id_User = id_user, Id_Role = id_role };
                roleUserReg.Add(userRole);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeleteRoleInUser(User user, int id_role, int id_user)
        {
            try
            {
                CheckRoles(user.Id_User);
                roleUserReg.Delete(id_role, id_user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
