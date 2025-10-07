using AspDotNetCore_WebAPIs.Services.Implementation;
using AspDotNetCore_WebAPIs.Services.Interfaces;

namespace AspDotNetCore_WebAPIs.Extentions.ServiceConfigration
{
    public static class ServiceConfigrations
    {
        public static IServiceCollection AddServiceConfigration(this IServiceCollection services)
            => services.AddScoped<IUserService, UserService>()
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

    }
}
