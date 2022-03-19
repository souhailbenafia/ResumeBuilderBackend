using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class userConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthPlace",
                schema: "dbo",
                table: "Users",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                schema: "dbo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "dbo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Genre",
                schema: "dbo",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "dbo",
                table: "Users",
                newName: "BirthPlace");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "Admin",
                column: "ConcurrencyStamp",
                value: "ac69bf6e-fca5-4c3a-b186-5f15de3b66a5");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "Employee",
                column: "ConcurrencyStamp",
                value: "e1970aaa-0103-40a7-8711-fbbace75ea95");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "Recruiter",
                column: "ConcurrencyStamp",
                value: "a8aa6fcc-5dfc-4e1d-845d-abaed1586d31");
        }
    }
}
