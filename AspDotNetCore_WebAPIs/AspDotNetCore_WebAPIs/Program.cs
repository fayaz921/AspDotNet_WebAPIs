using AspDotNetCore_WebAPIs.Data;
using AspDotNetCore_WebAPIs.Extentions.MiddleWareConfigration;
using AspDotNetCore_WebAPIs.Extentions.RepoConfigration;
using AspDotNetCore_WebAPIs.Extentions.ServiceConfigration;
using AspDotNetCore_WebAPIs.Repositories.Implementation;
using AspDotNetCore_WebAPIs.Repositories.Interfaces;
using AspDotNetCore_WebAPIs.Services.Implementation;
using AspDotNetCore_WebAPIs.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Add Db and Repo
builder.Services.AddRepoConfigration(builder.Configuration);
// Add services to the container.
builder.Services.AddServiceConfigration();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddMiddleWareConfigrations();   
app.Run();
