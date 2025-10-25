using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspDotNetCore_WebAPIs.Migrations
{
    /// <inheritdoc />
    public partial class addseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Contact", "Email", "FirstName", "ImageUrl", "LastName", "OTP", "PasswordHash", "PasswordSalt", "Role", "UserName" },
                values: new object[,]
                {
                    { new Guid("0312c103-0e89-448c-b299-1b8aca5f4d70"), "03089314932", "fayaz129@gmail.com", "Fayaz", "https://www.example.com/images/fayaz.jpg", "Ahmad", "1234", new byte[] { 179, 62, 165, 57, 99, 166, 134, 147, 251, 240, 47, 8, 22, 7, 224, 219, 144, 13, 234, 153, 68, 146, 219, 127, 194, 29, 84, 135, 33, 55, 251, 83, 241, 250, 229, 40, 208, 207, 174, 77, 87, 96, 82, 152, 126, 243, 122, 164, 49, 58, 77, 58, 197, 37, 82, 96, 220, 232, 76, 105, 211, 21, 124, 115 }, new byte[] { 47, 255, 149, 245, 89, 183, 198, 146, 228, 175, 233, 76, 63, 81, 205, 32, 120, 16, 236, 247, 249, 235, 130, 136, 179, 6, 141, 79, 110, 143, 149, 213, 92, 71, 125, 34, 115, 1, 226, 14, 78, 6, 202, 162, 17, 228, 136, 156, 41, 179, 27, 40, 180, 160, 44, 198, 152, 61, 179, 221, 245, 225, 80, 0, 193, 30, 31, 19, 27, 20, 193, 251, 28, 20, 175, 255, 39, 209, 41, 185, 126, 187, 241, 186, 220, 209, 232, 26, 129, 159, 80, 3, 159, 163, 205, 128, 141, 150, 160, 241, 9, 125, 107, 22, 86, 221, 111, 47, 74, 129, 250, 210, 150, 145, 170, 83, 143, 100, 208, 69, 43, 121, 6, 137, 138, 212, 221, 6 }, 0, "fayazahmad" },
                    { new Guid("f98aafcb-2614-48fe-9094-a8d088154464"), "030894234738", "fayaz573@gmail.com", "Fayaz", "https://www.example.com/images/fayaz.jpg", "Khan", "123", new byte[] { 179, 62, 165, 57, 99, 166, 134, 147, 251, 240, 47, 8, 22, 7, 224, 219, 144, 13, 234, 153, 68, 146, 219, 127, 194, 29, 84, 135, 33, 55, 251, 83, 241, 250, 229, 40, 208, 207, 174, 77, 87, 96, 82, 152, 126, 243, 122, 164, 49, 58, 77, 58, 197, 37, 82, 96, 220, 232, 76, 105, 211, 21, 124, 115 }, new byte[] { 47, 255, 149, 245, 89, 183, 198, 146, 228, 175, 233, 76, 63, 81, 205, 32, 120, 16, 236, 247, 249, 235, 130, 136, 179, 6, 141, 79, 110, 143, 149, 213, 92, 71, 125, 34, 115, 1, 226, 14, 78, 6, 202, 162, 17, 228, 136, 156, 41, 179, 27, 40, 180, 160, 44, 198, 152, 61, 179, 221, 245, 225, 80, 0, 193, 30, 31, 19, 27, 20, 193, 251, 28, 20, 175, 255, 39, 209, 41, 185, 126, 187, 241, 186, 220, 209, 232, 26, 129, 159, 80, 3, 159, 163, 205, 128, 141, 150, 160, 241, 9, 125, 107, 22, 86, 221, 111, 47, 74, 129, 250, 210, 150, 145, 170, 83, 143, 100, 208, 69, 43, 121, 6, 137, 138, 212, 221, 6 }, 0, "fayazkhan" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("0312c103-0e89-448c-b299-1b8aca5f4d70"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: new Guid("f98aafcb-2614-48fe-9094-a8d088154464"));

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
