using AspDotNetCore_WebAPIs.Extentions.MiddleWareConfigration;
using AspDotNetCore_WebAPIs.Extentions.RepoConfigration;
using AspDotNetCore_WebAPIs.Extentions.ServiceConfigration;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//Add Db and Repo
builder.Services.AddRepoConfigration(builder.Configuration);
// Add services to the container.
builder.Services.AddServiceConfigration()
                .AddSwaggerCongigration()
                .AddAuthentions(builder.Configuration)
                .AddFluentValidationAutoValidation();


builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddMiddleWareConfigrations();   
app.Run();
