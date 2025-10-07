using AspDotNetCore_WebAPIs.Data;
using AspDotNetCore_WebAPIs.Repositories.Implementation;
using AspDotNetCore_WebAPIs.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCore_WebAPIs.Extentions.RepoConfigration
{
    public static class RepoConfigrations
    {
        public static IServiceCollection AddRepoConfigration(this IServiceCollection services, IConfiguration configuration)
            => services.AddScoped<IUserRepo, UserRepo>()
            .AddDbContext<AppDBContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyConn")));

    }
}
