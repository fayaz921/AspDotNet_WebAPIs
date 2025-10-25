using AspDotNetCore_WebAPIs.Data.Entities;
using AspDotNetCore_WebAPIs.Data.Enums;
using AspDotNetCore_WebAPIs.Shared;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetCore_WebAPIs.Data
{
    public class AppDBContext(DbContextOptions<AppDBContext> options, IPasswordEncryptor passwordEncryptor) : DbContext(options)
    {
        private readonly IPasswordEncryptor _passwordEncryptor = passwordEncryptor;
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(SeedingUserData());
        }

        private List<User> SeedingUserData()
        {
            _passwordEncryptor.CreatePasswordHashandSalt("1234", out byte[] hash, out byte[] salt);

            return new List<User>()
            {

                new User()
                {
                    UserId = Guid.Parse("f98aafcb-2614-48fe-9094-a8d088154464"),
                    FirstName = "Fayaz",
                    LastName = "Khan",
                    Email = "fayaz573@gmail.com",
                    Role = Role.Admin,
                    UserName = "fayazkhan",
                    Contact = "030894234738",
                    ImageUrl = "https://www.example.com/images/fayaz.jpg",
                    OTP = "123",
                    PasswordHash = hash,
                    PasswordSalt = salt
                },
                new User
                {
                    UserId = Guid.Parse("0312c103-0e89-448c-b299-1b8aca5f4d70"),
                    FirstName = "Fayaz",
                    LastName = "Ahmad",
                    Email = "fayaz129@gmail.com",
                    Role = Role.Admin,
                    UserName = "fayazahmad",
                    Contact = "03089314932",
                    ImageUrl = "https://www.example.com/images/fayaz.jpg",
                    OTP = "1234",
                    PasswordHash = hash,
                    PasswordSalt = salt
                },
            };
          }
    
    }
}
