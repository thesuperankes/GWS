using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWS.Models;

namespace GWS.Repository
{
    public interface IUserRepository
    {
        User GetUserById(int user);
        User RegisterUser(User user);
        User GetUserByUsername(string username);
        User GetUserByEmail(string email);
    }
}
