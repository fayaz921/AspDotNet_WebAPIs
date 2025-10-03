using AspDotNetCore_WebAPIs.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCore_WebAPIs.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
    {
       public DbSet<User> Users { get; set; }
    }
}
