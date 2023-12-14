using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientShelters.Models;
using Grpc.Core;
using Grpc.Net.Client;

namespace ClientShelters.Controllers
{

    internal class AuthController
    {
        public User LogIn(string login, string password)
        {
            var req = new UserRequest()
            {
                UserName = login,
                Password = password
            };
            using var channel = GrpcChannel.ForAddress("https://localhost:7013");
            var client = new Authorization.AuthorizationClient(channel);
            var res = client.LogIn(req);
            return User.ToUser(res);
        }
    }
}
