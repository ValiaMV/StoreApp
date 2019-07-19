using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreApp.Migrations
{
    public partial class SeedDataIdentityUpdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "admin_user", "admin" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin_user");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                value: "6987786f-2890-416a-98d0-b91cabbf8c1b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "user",
                column: "ConcurrencyStamp",
                value: "07bcc844-ad6a-4042-8213-3a9191d4986e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin_user", 0, "fa7a2f71-0c78-4278-8964-8fbe8f6776a1", "admin@storeapp.valia", true, false, null, "ADMIN@STOREAPP.VALIA", "ADMIN", "AQAAAAEAACcQAAAAEL82bpjGsvYkuwuEV3OzI4HxHU86uoQkgZmDgYvuXZER/FclCIkIv0rrCE5ncldXHQ==", null, false, "27a57520-be6a-4ac7-9a1b-3d38b0b7f876", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "admin_user", "admin" });
        }
    }
}
