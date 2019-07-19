using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.Migrations
{
    public partial class AddUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "584a088d-7d5c-4c4c-80f9-edda714179ff", "d55e591f-762c-4435-8905-e678e50c9e0b", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2fc17d5e-d61a-453c-b98e-ae39b6acc965", "f570c04d-15f0-4c97-bbbd-acbabc4b327d", "User", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fc17d5e-d61a-453c-b98e-ae39b6acc965");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "584a088d-7d5c-4c4c-80f9-edda714179ff");
        }
    }
}
