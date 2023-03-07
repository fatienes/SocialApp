using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Models
{
    public interface ISocialRepository
    {
        Task<User> GetUsers(int id);
        Task<IEnumerable<User>> GetUsers();
        Task GetUser(int id);
    }
}