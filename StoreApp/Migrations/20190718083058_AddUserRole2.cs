using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.Migrations
{
    public partial class AddUserRole2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2fc17d5e-d61a-453c-b98e-ae39b6acc965");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "584a088d-7d5c-4c4c-80f9-edda714179ff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ce2e0c2b-750c-408e-aac2-9a8223662d79", "b444a1eb-956f-468a-afba-2316da81ae27", "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc5fdab9-b172-4e96-8024-a4be40d65ae2", "c91834bc-93c8-4dd5-9b92-3f3a2c91a2dc", "User", "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc5fdab9-b172-4e96-8024-a4be40d65ae2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ce2e0c2b-750c-408e-aac2-9a8223662d79");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "584a088d-7d5c-4c4c-80f9-edda714179ff", "d55e591f-762c-4435-8905-e678e50c9e0b", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2fc17d5e-d61a-453c-b98e-ae39b6acc965", "f570c04d-15f0-4c97-bbbd-acbabc4b327d", "User", null });
        }
    }
}
