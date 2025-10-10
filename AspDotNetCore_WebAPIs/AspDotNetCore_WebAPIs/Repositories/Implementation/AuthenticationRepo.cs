using AspDotNetCore_WebAPIs.Data;
using AspDotNetCore_WebAPIs.Data.Entities;
using AspDotNetCore_WebAPIs.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCore_WebAPIs.Repositories.Implementation
{
    public class AuthenticationRepo : IAuthenticationRepo
    {
        private readonly AppDBContext appDBContext;
        public AuthenticationRepo(AppDBContext appDB)
        {
            appDBContext = appDB;
        }
        public async Task<User> LoginAsync(User user)
        {
            //getting user creads from db
            var logininfo = await appDBContext.Users.FirstOrDefaultAsync(u => (u.Email == user.Email || u.UserName == user.UserName || u.Contact == user.Contact));
            return logininfo!;
        }

        public async Task<User> RegisterAsync(User user)
        {
            //adding user to db
            await appDBContext.Users.AddAsync(user);
            await appDBContext.SaveChangesAsync();
            return user;

        }

        public async Task<User> UserCheckAsync(User user)
        {
            //checking user if it exists in db
            var usercheck = await appDBContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email || u.Contact == user.Contact || u.UserName == user.UserName);
            return usercheck!;
        }
    }
}
