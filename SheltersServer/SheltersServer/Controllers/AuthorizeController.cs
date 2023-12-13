using Google.Protobuf.Collections;
using Grpc.Core;
using Microsoft.AspNetCore.Identity;
using SheltersServer.Models;


namespace SheltersServer.Services
{
    public class AuthorizeController : Authorization.AuthorizationBase
    {
        private readonly ILogger<AuthorizeController> _logger;
        private readonly AuthorizationService authorizationService = new AuthorizationService();
        public AuthorizeController(ILogger<AuthorizeController> logger)
        {
            _logger = logger;
        }
        public override Task<UserReply> LogIn(UserRequest request, ServerCallContext context)
        {
            User user = authorizationService.LogIn(request.UserName, request.Password);
            UserReply res = user.ToReply();
            var roles = authorizationService.GetRoles(user.Id_User);
            res.Roles.AddRange(roles);
            return Task.FromResult(res);
        }
    }
    
}
