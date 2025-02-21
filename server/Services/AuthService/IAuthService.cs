using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> GenerateJWT(string email);
        Task<string> HashPassword(string password);
        Task<bool> VerifyJWT(string token);
        Task<bool> VerifyPassword(string password, string hash);
    }
}