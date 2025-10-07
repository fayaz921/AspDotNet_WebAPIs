using AspDotNetCore_WebAPIs.Data;
using AspDotNetCore_WebAPIs.Data.Entities;
using AspDotNetCore_WebAPIs.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCore_WebAPIs.Repositories.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly AppDBContext appDBContext;
        public UserRepo(AppDBContext _appdb)
        {
            appDBContext = _appdb;
        }
        public async Task<User> RegisterAsync(User user)
        {
            var UserCheck = await appDBContext.Users.Where(u => u.Email == user.Email).FirstOrDefaultAsync();
            if(UserCheck == null)
            {
                await appDBContext.Users.AddAsync(user);
                await appDBContext.SaveChangesAsync();
                return user;
            }
            return null!;
        }
    }
}
