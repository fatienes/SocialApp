using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApp.Models;

namespace ServerApp.Data
{
    public class SocialRepository : ISocialRepository
    {
        private readonly SocialContext _context;
       public SocialRepository(SocialContext context)
       {
           _context=context;
       }

        public Task GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUsers(int id)
        {
            var user= await _context.Users.Include(i=>i.Images)
            .FirstOrDefaultAsync(i=>i.Id==id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
           var Users=await _context.Users.Include(i=>i.Images).ToListAsync();
           return Users;
        }
    }

}