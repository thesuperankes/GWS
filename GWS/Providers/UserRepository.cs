using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GWS.Models;
using GWS.Repository;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Remotion.Linq.Clauses;

namespace GWS.Providers
{
    public class UserRepository : IUserRepository
    {
        private gwsContext db = new gwsContext();

        public User GetUserById(int user)
        {
            var response = db.User.FirstOrDefault(s => s.Id == user);

            return response;
        }

        public User RegisterUser(User user)
        {
            try
            {
                db.User.Add(user);
                db.SaveChanges();

                var response = db.User.FirstOrDefault(u => u.Username == user.Username);
                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public User GetUserByUsername(string username)
        {
            try
            {
                var response = db.User.FirstOrDefault(s => s.Username == username);

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                var response = db.User.FirstOrDefault(s => s.Email == email);

                return response;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
