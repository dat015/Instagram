using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Services.UserSV
{
    public interface IUserRepo
    {
        Task<bool> IsUser(dynamic query);   
    }
}