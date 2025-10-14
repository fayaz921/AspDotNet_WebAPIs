using AspDotNetCore_WebAPIs.Services.Implementation;
using AspDotNetCore_WebAPIs.Services.Interfaces;
using AspDotNetCore_WebAPIs.Utilities;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace AspDotNetCore_WebAPIs.Extentions.ServiceConfigration
{
    public static class ServiceConfigrations
    {
        public static IServiceCollection AddServiceConfigration(this IServiceCollection services)
                                                => services.AddScoped<IUserService, UserService>()
                                                           .AddEndpointsApiExplorer()
                                                           .AddScoped<IAuthenticationService, AuthenticationService>()
                                                           .AddScoped<IJWTTokenService,JWTTokenService>();
                                                           

        public static IServiceCollection AddSwaggerCongigration(this IServiceCollection services)
        
          => services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "AspDotNetCore_WebAPIs",
                    Version = "v1",
                });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                   In = ParameterLocation.Header,
                   Name = "Authorization",
                   Scheme = "Bearer",
                   Type = SecuritySchemeType.ApiKey,
                });
                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        
                                               

    }
}
