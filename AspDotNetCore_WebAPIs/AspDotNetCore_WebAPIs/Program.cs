using AspDotNetCore_WebAPIs.Extentions.MiddleWareConfigration;
using AspDotNetCore_WebAPIs.Extentions.RepoConfigration;
using AspDotNetCore_WebAPIs.Extentions.ServiceConfigration;

var builder = WebApplication.CreateBuilder(args);
//Add Db and Repo
builder.Services.AddRepoConfigration(builder.Configuration);
// Add services to the container.
builder.Services.AddServiceConfigration()
                .AddSwaggerCongigration()
                .AddAuthentions(builder.Configuration);
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.AddMiddleWareConfigrations();   
app.Run();
