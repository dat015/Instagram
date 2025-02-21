using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.UserSV
{
    public class UserRepo : IUserRepo
    {
        

        Task<bool> IUserRepo.IsUser(dynamic query)
        {
            throw new NotImplementedException();
        }
    }
}