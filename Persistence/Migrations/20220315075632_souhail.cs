using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class souhail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "9c71fb05-1690-439c-9e83-d3725c64c906");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "041d6c2c-e629-493d-a614-5fbba6b8d441");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "Recruiter",
                column: "ConcurrencyStamp",
                value: "e1ff3d6c-3758-4aa3-83c9-af3cc86547f0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "69220418-5912-44cc-a28b-0989f11a98cc");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "e15eed0c-1d86-40ad-98a4-e784095bd25d");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "Recruiter",
                column: "ConcurrencyStamp",
                value: "e7714d96-2981-4e94-87f5-2a9403ec0f9f");
        }
    }
}
