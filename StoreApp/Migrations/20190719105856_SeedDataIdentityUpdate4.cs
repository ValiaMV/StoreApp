using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.Migrations
{
    public partial class SeedDataIdentityUpdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6fa3bb70-0ec0-47f9-a786-bfc0bd6d287f", "admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6fa3bb70-0ec0-47f9-a786-bfc0bd6d287f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "5900a2ef-5dba-4df6-a542-47029ae5c93a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "a8a3b45b-8373-4dab-b902-6bf8d5c46e1b");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6b55403b-2719-4638-aa7e-3345b6af6eef", 0, "94ca6a93-5ab0-4921-b857-9832c4453f2c", "admin@storeapp.valia", true, false, null, "admin@storeapp.valia", "admin@storeapp.valia", "AQAAAAEAACcQAAAAEDTuug9VccsK1XHCCku0MqxN3OjYX/VzW6y7HERh8xI9uf1aWmBowai991XaCs1KdQ==", null, false, "e08295e9-51a9-4c6d-9454-c30ad99195bf", false, "admin@storeapp.valia" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "6b55403b-2719-4638-aa7e-3345b6af6eef", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "6b55403b-2719-4638-aa7e-3345b6af6eef", "admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6b55403b-2719-4638-aa7e-3345b6af6eef");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "admin",
                column: "ConcurrencyStamp",
                value: "05f66150-f950-4be7-a63f-f5c6de25a59f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "c8f7d0da-9f29-4322-b3c3-e44128ff19e8");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6fa3bb70-0ec0-47f9-a786-bfc0bd6d287f", 0, "eea59620-1eb0-49b9-8858-a7a95f760e59", "admin@storeapp.valia", true, false, null, "admin@storeapp.valia", "Admin", "AQAAAAEAACcQAAAAED9fRH/bS3CeQvhmOYBT9qpdL2fhAmYZuRUldLSDBfDVdVojgyEjWCaIQ2avWME0tw==", null, false, "8fb9e010-eded-4a89-86c9-0d9559a59e8d", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "6fa3bb70-0ec0-47f9-a786-bfc0bd6d287f", "admin" });
        }
    }
}
