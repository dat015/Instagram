using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public Task<string> GenerateJWT(string email)
        {
            throw new NotImplementedException();
        }

        public Task<string> HashPassword(string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyJWT(string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyPassword(string password, string hash)
        {
            throw new NotImplementedException();
        }
    }
}