using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientShelters.Models
{
    public class User : IMyModel
    {
        public int Id_User { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int Id_Shelter { get; set; }
        public Shelter? Shelter { get; set; }
        public List<UserRole>? UserRole { get; set; }

        public UserReply ToReply()
        {
            return new UserReply()
            {
                IdUser = Id_User,
                Name = Name,
                Surname = Surname,
                LastName = LastName,
                UserName = UserName,
                Password = Password,
                IdShelter = Id_Shelter,
            };
        }

        public static User ToUser(UserReply reply)
        {
            return new User()
            {
                Id_User = reply.IdUser,
                Name = reply.Name,
                Surname = reply.Surname,
                LastName = reply.LastName,
                UserName = reply.UserName,
                Password = reply.Password,
                Id_Shelter = reply.IdShelter,
            };
        }
    }
}
