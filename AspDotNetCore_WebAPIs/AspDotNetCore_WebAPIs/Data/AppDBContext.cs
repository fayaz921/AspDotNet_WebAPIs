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
                    UserId = Guid.Parse("256de607-fe80-4297-b54a-056f620baf86"),
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
                    UserId = Guid.Parse("a5dd970a-8e4b-49ac-87b9-34967ad9d79c"),
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
