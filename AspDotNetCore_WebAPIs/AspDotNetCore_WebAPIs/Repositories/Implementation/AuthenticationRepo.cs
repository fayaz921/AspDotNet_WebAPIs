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
           var logininfo = await appDBContext.Users.FirstOrDefaultAsync(u => (u.Email == user.Email || u.UserName == user.UserName || u.Contact == user.Contact));
           return logininfo;
        }

        public async Task<User> RegisterAsync(User user)
        {
            var usercheck = await  appDBContext.Users.FirstOrDefaultAsync(u=>u.Email==user.Email || u.Contact==user.Contact ||u.UserName == user.UserName );
            if(usercheck == null)
            {
                await appDBContext.Users.AddAsync(user);
                await appDBContext.SaveChangesAsync();
                return user;
            }
            return usercheck;
        }
    }
}
