using AspDotNetCore_WebAPIs.Dtos.Authentication;
using AspDotNetCore_WebAPIs.Services.Implementation;
using AspDotNetCore_WebAPIs.Services.Interfaces;
using AspDotNetCore_WebAPIs.Shared;
using AspDotNetCore_WebAPIs.Utilities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace AspDotNetCore_WebAPIs.Extentions.ServiceConfigration
{
    public static class ServiceConfigrations
    {
        //Service Configuration
        public static IServiceCollection AddServiceConfigration(this IServiceCollection services)
                                                => services.AddScoped<IUserService, UserService>()
                                                           .AddEndpointsApiExplorer()
                                                           .AddScoped<IAuthenticationService, AuthenticationService>()
                                                           .AddScoped<IJWTTokenService, JWTTokenService>()
                                                           .AddScoped<IPasswordEncryptor,PasswordEncryptor>();


        //Swagger Configuration
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

                // Include XML comments for documentation (if available)
                var assembly = Assembly.GetExecutingAssembly();
                var xmlFile = $"{assembly.GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            
    });

        //JWT Authentication
        public static IServiceCollection AddAuthentions(this IServiceCollection services, IConfiguration configuration)
        {
            var tokenkey = configuration.GetSection("Token").Value;
            var issuer = configuration.GetSection("IssuerKey").Value;
            var audience = configuration.GetSection("AudienceKey").Value;
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidAudience = audience,
                            ValidIssuer = issuer,
                            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenkey!)),
                            ValidateIssuerSigningKey = true,
                            ValidateLifetime = true,
                        };
                    });
            return services;
        }


        //Fluent Validation
        public static IServiceCollection AddFluentValidationConfigration(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<UserRegisterDto>();
            services.AddFluentValidationAutoValidation();
            return services;
        }

        //Serilog configuration
        public static IHostBuilder AddSerilog(this IHostBuilder hostBuilder, IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            return hostBuilder.UseSerilog();
        }

    }
}
