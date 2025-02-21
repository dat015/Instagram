using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTO;
using server.Models;

namespace server.Services.UserSV
{
    public interface IUserRepo
    {
        Task<bool> IsUser(string username, string phoneNumber, string email); 
        Task<User> AddNewUser(UserDTO model);  
    }
}